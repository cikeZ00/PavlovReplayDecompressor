using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using PavlovReplayReader;
using PavlovReplayReader.Models;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayViewer;

public partial class MainWindow : Window
{
    private PavlovReplay? _replay;
    private ReplayTimeline? _timeline;
    private ReplayReader? _reader;
    
    private readonly DispatcherTimer _playbackTimer;
    private bool _isPlaying;
    private float _currentTime;
    private float _maxTime;
    private double _playbackSpeed = 1.0;
    
    // Map & playback state
    private readonly Dictionary<uint, Ellipse> _pawnMarkers = new(); // keyed by pawn channel index
    private readonly Dictionary<ulong, SolidColorBrush> _playerBrushes = new(); // keyed by player id to keep color across pawns
    private double _mapScale = 1.0;
    private bool _isPanning = false;
    private Point _lastPanPoint;
    private float _mapMinX = -2000, _mapMaxX = 2000, _mapMinY = -2000, _mapMaxY = 2000;
    private const double MarkerSize = 12.0;

    // Event view models
    private readonly List<EventViewModel> _eventViewModels = new();
    
    public MainWindow()
    {
        InitializeComponent();
        
        _playbackTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(16) // ~60fps
        };
        _playbackTimer.Tick += PlaybackTimer_Tick;
        
        // Initialize reader
        var serviceCollection = new ServiceCollection()
            .AddLogging(loggingBuilder => loggingBuilder.SetMinimumLevel(LogLevel.Error));
        var provider = serviceCollection.BuildServiceProvider();
        var logger = provider.GetService<ILogger<MainWindow>>();
        
        _reader = new ReplayReader(logger, ParseMode.Normal);
        _reader.RecordTimeline = true;
        _reader.SnapshotInterval = 0.05f; // 50ms snapshots for smoother playback
    }
    
    private void LoadButton_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Pavlov Replay Files (*.pavlov;*.replay)|*.pavlov;*.replay|All Files (*.*)|*.*",
            Title = "Select Pavlov Replay File"
        };
        
        if (dialog.ShowDialog() == true)
        {
            LoadReplay(dialog.FileName);
        }
    }
    
    private void LoadReplay(string filePath)
    {
        try
        {
            Mouse.OverrideCursor = Cursors.Wait;
            
            // Reset state
            StopPlayback();
            _eventViewModels.Clear();
            
            // Parse replay
            _replay = _reader!.ReadReplay(filePath);
            _timeline = _reader.GetTimeline();
            
            if (_replay == null || _timeline == null)
            {
                MessageBox.Show("Failed to parse replay file.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            // Update UI
            FileNameText.Text = System.IO.Path.GetFileName(filePath);
            
            // Game info
            GameModeText.Text = $"Mode: {_replay.GameData?.GameModeType?.ToString() ?? "Unknown"}";
            // Use timeline duration as fallback if stats duration is not available
            var duration = _replay.Stats?.ReplayDuration ?? 
                          (_timeline.Duration > 0 ? _timeline.Duration : 
                           (_timeline.PawnTimelines?.SelectMany(p => p.Snapshots).MaxBy(s => s.Time)?.Time ?? 0));
            DurationText.Text = $"Duration: {FormatTime(duration)}";
            MapText.Text = $"Map: {_replay.GameData?.ModId ?? "Unknown"}";
            Team0ScoreText.Text = (_replay.GameData?.Team0Score ?? 0).ToString();
            Team1ScoreText.Text = (_replay.GameData?.Team1Score ?? 0).ToString();
            
            // Players
            if (_replay.Players != null)
            {
                Team0PlayersList.ItemsSource = _replay.Players.Where(p => p.TeamId == 0).ToList();
                Team1PlayersList.ItemsSource = _replay.Players.Where(p => p.TeamId == 1).ToList();
            }
            
            // Events
            if (_timeline.Events != null)
            {
                foreach (var evt in _timeline.Events.OrderBy(e => e.Time))
                {
                    _eventViewModels.Add(new EventViewModel
                    {
                        Time = evt.Time,
                        EventType = evt.EventType,
                        Description = evt.Description ?? ""
                    });
                }
            }
            EventsList.ItemsSource = _eventViewModels;
            
            // Timeline setup
            _maxTime = _replay.Stats?.ReplayDuration ?? 
                       _timeline.PawnTimelines.SelectMany(p => p.Snapshots).MaxBy(s => s.Time)?.Time ?? 0;
            
            TimelineSlider.Maximum = _maxTime;
            TimelineSlider.Value = 0;
            TimelineSlider.IsEnabled = true;
            CurrentTimeLabelEnd.Text = FormatTime(_maxTime);
            
            // Enable controls
            PlayPauseButton.IsEnabled = true;
            StopButton.IsEnabled = true;

            // Initialize map and precompute bounds/colors
            InitializeMapTransforms();
            AssignPlayerColorsAndBounds();
            UpdateMapAtTime(0);
            
            Mouse.OverrideCursor = null;
        }
        catch (Exception ex)
        {
            Mouse.OverrideCursor = null;
            MessageBox.Show($"Error loading replay: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    
    



























    
    #region Map

    private void InitializeMapTransforms()
    {
        if (MapCanvas == null) return;
        var tg = new TransformGroup();
        var st = new ScaleTransform(_mapScale, _mapScale);
        var tt = new TranslateTransform(0, 0);
        tg.Children.Add(st);
        tg.Children.Add(tt);
        MapCanvas.RenderTransform = tg;
    }

    private ScaleTransform? GetScaleTransform() => (MapCanvas.RenderTransform as TransformGroup)?.Children.OfType<ScaleTransform>().FirstOrDefault();
    private TranslateTransform? GetTranslateTransform() => (MapCanvas.RenderTransform as TransformGroup)?.Children.OfType<TranslateTransform>().FirstOrDefault();

    private void AssignPlayerColorsAndBounds()
    {
        if (_timeline == null) return;
        float minX = float.MaxValue, minY = float.MaxValue, maxX = float.MinValue, maxY = float.MinValue;
        foreach (var pt in _timeline.PawnTimelines)
        {
            foreach (var s in pt.Snapshots)
            {
                if (s.Location == null || !s.IsPositionValid) continue;
                minX = Math.Min(minX, (float)s.Location.X);
                minY = Math.Min(minY, (float)s.Location.Y);
                maxX = Math.Max(maxX, (float)s.Location.X);
                maxY = Math.Max(maxY, (float)s.Location.Y);
            }
        }
        if (minX == float.MaxValue)
        {
            minX = -2000; minY = -2000; maxX = 2000; maxY = 2000;
        }
        _mapMinX = minX; _mapMinY = minY; _mapMaxX = maxX; _mapMaxY = maxY;

        var rand = new Random(0);
        foreach (var pt in _timeline.PawnTimelines)
        {
            if (pt.PlayerId.HasValue)
            {
                ulong pid = pt.PlayerId.Value;
                if (!_playerBrushes.ContainsKey(pid))
                {
                    SolidColorBrush brush;
                    if (pt.TeamId == 0) brush = new SolidColorBrush(Color.FromRgb(0x3A,0x6E,0xA5));
                    else if (pt.TeamId == 1) brush = new SolidColorBrush(Color.FromRgb(0xA5,0x3A,0x3A));
                    else brush = new SolidColorBrush(Color.FromRgb((byte)rand.Next(60,220), (byte)rand.Next(60,220), (byte)rand.Next(60,220)));
                    brush.Freeze();
                    _playerBrushes[pid] = brush;
                }
            }
        }
    }

    private Point MapWorldToCanvas(FVector world)
    {
        double worldWidth = _mapMaxX - _mapMinX;
        double worldHeight = _mapMaxY - _mapMinY;
        if (worldWidth <= 0) worldWidth = 4000;
        if (worldHeight <= 0) worldHeight = 4000;
        double xRatio = (world.X - _mapMinX) / worldWidth;
        double yRatio = (world.Y - _mapMinY) / worldHeight;
        double canvasX = xRatio * MapCanvas.Width;
        double canvasY = (1 - yRatio) * MapCanvas.Height; // invert Y so higher world Y is up
        return new Point(canvasX, canvasY);
    }

    private PawnSnapshot? GetSnapshotForPawnAtTime(PawnTimeline pt, float time)
    {
        if (pt.Snapshots.Count == 0) return null;
        int i = pt.Snapshots.BinarySearch(new PawnSnapshot { Time = time }, Comparer<PawnSnapshot>.Create((a,b)=>a.Time.CompareTo(b.Time)));
        if (i >= 0) return pt.Snapshots[i];
        int index = ~i - 1;
        if (index < 0) return null;
        return pt.Snapshots[index];
    }

    private void UpdateMapAtTime(float time)
    {
        if (_timeline == null || MapCanvas == null) return;
        var seenChannels = new HashSet<uint>();
        foreach (var pt in _timeline.PawnTimelines)
        {
            var snap = GetSnapshotForPawnAtTime(pt, time);
            if (snap == null || snap.Location == null || !snap.IsPositionValid || snap.IsDead)
            {
                if (_pawnMarkers.TryGetValue(pt.ChannelIndex, out var existing))
                {
                    existing.Visibility = Visibility.Collapsed;
                }
                continue;
            }
            Point pos = MapWorldToCanvas(snap.Location);
            if (!_pawnMarkers.TryGetValue(pt.ChannelIndex, out var ellipse))
            {
                ellipse = new Ellipse
                {
                    Width = MarkerSize,
                    Height = MarkerSize,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1.5,
                    ToolTip = pt.PlayerName ?? ($"Pawn {pt.ChannelIndex}")
                };
                ellipse.MouseLeftButtonDown += Marker_MouseLeftButtonDown;
                ellipse.Tag = pt.ChannelIndex;
                MapCanvas.Children.Add(ellipse);
                _pawnMarkers[pt.ChannelIndex] = ellipse;
            }

            SolidColorBrush brush = Brushes.Gray;
            if (pt.PlayerId.HasValue && _playerBrushes.TryGetValue(pt.PlayerId.Value, out var b)) brush = b;
            else if (pt.TeamId == 0) brush = new SolidColorBrush(Color.FromRgb(0x3A,0x6E,0xA5));
            else if (pt.TeamId == 1) brush = new SolidColorBrush(Color.FromRgb(0xA5,0x3A,0x3A));
            ellipse.Fill = brush;

            Canvas.SetLeft(ellipse, pos.X - ellipse.Width/2);
            Canvas.SetTop(ellipse, pos.Y - ellipse.Height/2);
            ellipse.Visibility = Visibility.Visible;

            ellipse.ToolTip = $"{pt.PlayerName ?? "Player"} (Ch:{pt.ChannelIndex})\n{time:F2}s\nX:{(int)snap.Location.X} Y:{(int)snap.Location.Y} Z:{(int)snap.Location.Z}";

            seenChannels.Add(pt.ChannelIndex);
        }

        foreach (var kv in _pawnMarkers.ToList())
        {
            if (!seenChannels.Contains(kv.Key))
            {
                kv.Value.Visibility = Visibility.Collapsed;
            }
        }
    }

    private void Marker_MouseLeftButtonDown(object? sender, MouseButtonEventArgs e)
    {
        if (sender is Ellipse ellipse && MapCanvas != null)
        {
            if (ellipse.Tag is uint channel)
            {
                double left = Canvas.GetLeft(ellipse) + ellipse.Width/2;
                double top = Canvas.GetTop(ellipse) + ellipse.Height/2;
                var st = GetScaleTransform();
                var tt = GetTranslateTransform();
                if (st == null || tt == null) return;
                var viewportCenter = new Point(MapScrollViewer.ViewportWidth/2, MapScrollViewer.ViewportHeight/2);
                tt.X = viewportCenter.X - left * st.ScaleX;
                tt.Y = viewportCenter.Y - top * st.ScaleY;
            }
        }
    }

    private void MapCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
    {
        var st = GetScaleTransform();
        if (st == null) return;
        double oldScale = st.ScaleX;
        double newScale = Math.Clamp(oldScale * (e.Delta > 0 ? 1.1 : 0.9), 0.1, 8.0);
        st.ScaleX = st.ScaleY = newScale;
        MapInfoText.Text = $"Zoom: {(int)(newScale * 100)}% - Drag to pan (use mouse wheel to zoom). Click marker to center.";
    }

    private void MapCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _isPanning = true;
        _lastPanPoint = e.GetPosition(MapScrollViewer);
        MapCanvas.CaptureMouse();
    }

    private void MapCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        _isPanning = false;
        MapCanvas.ReleaseMouseCapture();
    }

    private void MapCanvas_MouseMove(object sender, MouseEventArgs e)
    {
        if (!_isPanning) return;
        var cur = e.GetPosition(MapScrollViewer);
        var delta = cur - _lastPanPoint;
        var tt = GetTranslateTransform();
        if (tt == null) return;
        tt.X += delta.X;
        tt.Y += delta.Y;
        _lastPanPoint = cur;
    }

#endregion

#region Playback Controls
    
    private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
    {
        if (_isPlaying)
        {
            PausePlayback();
        }
        else
        {
            StartPlayback();
        }
    }
    
    private void StopButton_Click(object sender, RoutedEventArgs e)
    {
        StopPlayback();
    }
    
    private void StartPlayback()
    {
        _isPlaying = true;
        PlayPauseButton.Content = "⏸ Pause";
        _playbackTimer.Start();
    }
    
    private void PausePlayback()
    {
        _isPlaying = false;
        PlayPauseButton.Content = "▶ Play";
        _playbackTimer.Stop();
    }
    
    private void StopPlayback()
    {
        PausePlayback();
        _currentTime = 0;
        TimelineSlider.Value = 0;
    }
    
    private void PlaybackTimer_Tick(object? sender, EventArgs e)
    {
        if (!_isPlaying) return;
        
        _currentTime += (float)(0.016 * _playbackSpeed); // ~16ms per tick
        
        if (_currentTime >= _maxTime)
        {
            _currentTime = _maxTime;
            PausePlayback();
        }
        
        // Update slider without triggering ValueChanged
        TimelineSlider.ValueChanged -= TimelineSlider_ValueChanged;
        TimelineSlider.Value = _currentTime;
        TimelineSlider.ValueChanged += TimelineSlider_ValueChanged;

        // Update map display for current time
        UpdateMapAtTime(_currentTime);
    }
    
    private void TimelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _currentTime = (float)e.NewValue;
        UpdateMapAtTime(_currentTime);
    }
    
    private void SpeedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _playbackSpeed = SpeedComboBox.SelectedIndex switch
        {
            0 => 0.25,
            1 => 0.5,
            2 => 1.0,
            3 => 2.0,
            4 => 4.0,
            _ => 1.0
        };
    }
    
    #endregion
    
    #region Events
    
    private void EventsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (EventsList.SelectedItem is EventViewModel evt)
        {
            // Jump to event time
            _currentTime = evt.Time;
            TimelineSlider.Value = _currentTime;
        }
    }
    
    #endregion
    
    #region Helpers
    
    private static string FormatTime(float? seconds)
    {
        if (seconds == null) return "0:00";
        var ts = TimeSpan.FromSeconds(seconds.Value);
        return ts.TotalHours >= 1 
            ? $"{(int)ts.TotalHours}:{ts.Minutes:D2}:{ts.Seconds:D2}"
            : $"{(int)ts.TotalMinutes}:{ts.Seconds:D2}";
    }
    
    #endregion
}

/// <summary>
/// View model for event list items.
/// </summary>
public class EventViewModel
{
    public float Time { get; set; }
    public string TimeFormatted => TimeSpan.FromSeconds(Time).ToString(@"m\:ss");
    public string EventType { get; set; } = "";
    public string Description { get; set; } = "";
}
