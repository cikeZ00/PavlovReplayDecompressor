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
            
            Mouse.OverrideCursor = null;
        }
        catch (Exception ex)
        {
            Mouse.OverrideCursor = null;
            MessageBox.Show($"Error loading replay: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    
    



























    
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
    }
    
    private void TimelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _currentTime = (float)e.NewValue;
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
