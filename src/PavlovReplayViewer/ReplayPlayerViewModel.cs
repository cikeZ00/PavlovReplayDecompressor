using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using PavlovReplayReader;
using PavlovReplayReader.Models;
using Unreal.Core.Models.Enums;

namespace PavlovReplayViewer;

/// <summary>
/// View model for the replay player, managing playback state and timeline data.
/// </summary>
public class ReplayPlayerViewModel : INotifyPropertyChanged, IDisposable
{
    private readonly DispatcherTimer _playbackTimer;
    private PavlovReplay? _replay;
    private ReplayTimeline? _timeline;
    private bool _isPlaying;
    private double _currentTime;
    private double _totalDuration;
    private double _playbackSpeed = 1.0;
    private string _replayFileName = string.Empty;
    private bool _isReplayLoaded;
    private bool _wasPausedForSeek;

    public ReplayPlayerViewModel()
    {
        // Initialize commands
        PlayPauseCommand = new RelayCommand(PlayPause);
        StopCommand = new RelayCommand(Stop);
        GoToStartCommand = new RelayCommand(GoToStart);
        GoToEndCommand = new RelayCommand(GoToEnd);
        SkipForwardCommand = new RelayCommand(() => Skip(10));
        SkipBackwardCommand = new RelayCommand(() => Skip(-10));
        SetSpeedCommand = new RelayCommand(SetSpeed);

        // Initialize timer for playback - reduced to 30 FPS for better performance
        _playbackTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(33) // ~30 FPS instead of 60
        };
        _playbackTimer.Tick += PlaybackTimer_Tick;

        Players = new ObservableCollection<PlayerViewModel>();
        CurrentPlayerPositions = new ObservableCollection<PlayerPosition>();
    }

    #region Properties

    public bool IsReplayLoaded
    {
        get => _isReplayLoaded;
        private set
        {
            _isReplayLoaded = value;
            OnPropertyChanged();
            ((RelayCommand)PlayPauseCommand).RaiseCanExecuteChanged();
            ((RelayCommand)StopCommand).RaiseCanExecuteChanged();
            ((RelayCommand)GoToStartCommand).RaiseCanExecuteChanged();
            ((RelayCommand)GoToEndCommand).RaiseCanExecuteChanged();
            ((RelayCommand)SkipForwardCommand).RaiseCanExecuteChanged();
            ((RelayCommand)SkipBackwardCommand).RaiseCanExecuteChanged();
            ((RelayCommand)SetSpeedCommand).RaiseCanExecuteChanged();
        }
    }

    public string ReplayFileName
    {
        get => _replayFileName;
        private set
        {
            _replayFileName = value;
            OnPropertyChanged();
        }
    }

    public string MapName => _replay?.Info?.FriendlyName ?? "Unknown";
    public string GameMode => _replay?.GameData?.GameModeType?.ToString() ?? "Unknown";

    public double CurrentTime
    {
        get => _currentTime;
        set
        {
            if (Math.Abs(_currentTime - value) > 0.001)
            {
                // If jumping more than 1 second, clear trails to prevent incorrect connections
                if (Math.Abs(value - _currentTime) > 1.0)
                {
                    ClearTrailsRequested?.Invoke(this, EventArgs.Empty);
                }
                
                _currentTime = Math.Clamp(value, 0, _totalDuration);
                OnPropertyChanged();
                UpdateStateAtTime(_currentTime);
            }
        }
    }

    public double TotalDuration
    {
        get => _totalDuration;
        private set
        {
            _totalDuration = value;
            OnPropertyChanged();
        }
    }

    public double PlaybackSpeed
    {
        get => _playbackSpeed;
        private set
        {
            _playbackSpeed = value;
            OnPropertyChanged();
        }
    }

    public bool IsPlaying
    {
        get => _isPlaying;
        private set
        {
            _isPlaying = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(PlayPauseButtonText));
        }
    }

    public string PlayPauseButtonText => IsPlaying ? "⏸ Pause" : "▶ Play";

    public ObservableCollection<PlayerViewModel> Players { get; }
    public ObservableCollection<PlayerPosition> CurrentPlayerPositions { get; }

    // Event to notify when trails should be cleared
    public event EventHandler? ClearTrailsRequested;

    #endregion

    #region Commands

    public ICommand PlayPauseCommand { get; }
    public ICommand StopCommand { get; }
    public ICommand GoToStartCommand { get; }
    public ICommand GoToEndCommand { get; }
    public ICommand SkipForwardCommand { get; }
    public ICommand SkipBackwardCommand { get; }
    public ICommand SetSpeedCommand { get; }

    #endregion

    #region Public Methods

    public void LoadReplay(string filePath)
    {
        Stop();
        
        try
        {
            var reader = new ReplayReader(parseMode: ParseMode.Full)
            {
                RecordTimeline = true,
                SnapshotInterval = 0.1f // 10 snapshots per second
            };

            _replay = reader.ReadReplay(filePath);
            _timeline = reader.GetTimeline();

            ReplayFileName = System.IO.Path.GetFileName(filePath);
            TotalDuration = _replay.Stats?.ReplayDuration ?? 0;
            
            // Initialize player list
            Players.Clear();
            if (_replay.Players != null)
            {
                foreach (var player in _replay.Players)
                {
                    Players.Add(new PlayerViewModel(player));
                }
            }

            CurrentTime = 0;
            IsReplayLoaded = true;
            
            OnPropertyChanged(nameof(MapName));
            OnPropertyChanged(nameof(GameMode));
            
            UpdateStateAtTime(0);
        }
        catch (Exception ex)
        {
            IsReplayLoaded = false;
            throw new Exception($"Failed to load replay: {ex.Message}", ex);
        }
    }

    public void PauseForSeek()
    {
        _wasPausedForSeek = !IsPlaying;
        if (IsPlaying)
        {
            _playbackTimer.Stop();
        }
    }

    public void ResumeFromSeek()
    {
        if (!_wasPausedForSeek && IsPlaying)
        {
            _playbackTimer.Start();
        }
    }

    #endregion

    #region Private Methods

    private void PlayPause()
    {
        if (IsPlaying)
        {
            _playbackTimer.Stop();
            IsPlaying = false;
        }
        else
        {
            if (CurrentTime >= TotalDuration)
            {
                CurrentTime = 0;
            }
            _playbackTimer.Start();
            IsPlaying = true;
        }
    }

    private void Stop()
    {
        _playbackTimer.Stop();
        IsPlaying = false;
        ClearTrailsRequested?.Invoke(this, EventArgs.Empty);
        CurrentTime = 0;
    }

    private void GoToStart()
    {
        ClearTrailsRequested?.Invoke(this, EventArgs.Empty);
        CurrentTime = 0;
    }

    private void GoToEnd()
    {
        CurrentTime = TotalDuration;
    }

    private void Skip(double seconds)
    {
        CurrentTime += seconds;
    }

    private void SetSpeed(object? parameter)
    {
        if (parameter is double speed)
        {
            PlaybackSpeed = speed;
        }
        else if (parameter is string speedStr && double.TryParse(speedStr, out var parsedSpeed))
        {
            PlaybackSpeed = parsedSpeed;
        }
    }

    private void PlaybackTimer_Tick(object? sender, EventArgs e)
    {
        CurrentTime += _playbackTimer.Interval.TotalSeconds * PlaybackSpeed;
        
        if (CurrentTime >= TotalDuration)
        {
            CurrentTime = TotalDuration;
            _playbackTimer.Stop();
            IsPlaying = false;
        }
    }

    private void UpdateStateAtTime(double time)
    {
        if (_timeline?.PawnTimelines == null || _replay == null)
            return;

        // Batch update player positions to avoid multiple collection change events
        var newPositions = new List<PlayerPosition>();
        
        foreach (var pawnTimeline in _timeline.PawnTimelines)
        {
            // Find the snapshot at the current time
            var snapshot = FindSnapshotAtTime(pawnTimeline, (float)time);
            if (snapshot?.Location != null && snapshot.IsPositionValid)
            {
                var playerData = _replay.Players?.FirstOrDefault(p => 
                    p.PlayerId.ToString() == pawnTimeline.PlayerId?.ToString());

                newPositions.Add(new PlayerPosition
                {
                    X = (float)snapshot.Location.X,
                    Y = (float)snapshot.Location.Y,
                    Z = (float)snapshot.Location.Z,
                    Rotation = snapshot.Rotation?.Yaw ?? 0,
                    PlayerName = pawnTimeline.PlayerName ?? "Unknown",
                    TeamId = playerData?.TeamId ?? 0,
                    IsDead = snapshot.IsDead
                });
            }
        }

        // Clear and add all at once for better performance
        CurrentPlayerPositions.Clear();
        foreach (var pos in newPositions)
        {
            CurrentPlayerPositions.Add(pos);
        }

        // Update player stats less frequently (only dead status)
        foreach (var playerVM in Players)
        {
            var pawnTimeline = _timeline.PawnTimelines.FirstOrDefault(pt => 
                pt.PlayerName == playerVM.PlayerName);
            
            if (pawnTimeline != null)
            {
                var snapshot = FindSnapshotAtTime(pawnTimeline, (float)time);
                playerVM.IsDead = snapshot?.IsDead ?? false;
            }
        }
    }

    private PawnSnapshot? FindSnapshotAtTime(PawnTimeline timeline, float time)
    {
        if (timeline.Snapshots == null || timeline.Snapshots.Count == 0)
            return null;

        // Binary search for the snapshot at or before the given time
        var snapshots = timeline.Snapshots;
        int left = 0;
        int right = snapshots.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            
            if (Math.Abs(snapshots[mid].Time - time) < 0.05f)
                return snapshots[mid];
            
            if (snapshots[mid].Time < time)
                left = mid + 1;
            else
                right = mid - 1;
        }

        // Return the closest snapshot before the time
        if (right >= 0 && right < snapshots.Count)
            return snapshots[right];
        
        return null;
    }

    #endregion

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

    #region IDisposable

    public void Dispose()
    {
        _playbackTimer?.Stop();
        GC.SuppressFinalize(this);
    }

    #endregion
}

/// <summary>
/// View model for individual player display.
/// </summary>
public class PlayerViewModel : INotifyPropertyChanged
{
    private readonly PlayerData _playerData;
    private bool _isDead;

    public PlayerViewModel(PlayerData playerData)
    {
        _playerData = playerData;
        _isDead = playerData.bDead;
    }

    public string PlayerName => _playerData.PlayerName ?? "Unknown";
    public int TeamId => _playerData.TeamId;
    public int Kills => _playerData.Kills;
    public int Deaths => _playerData.Deaths;
    public int Assists => _playerData.Assists;
    public float Score => _playerData.Score;

    public bool IsDead
    {
        get => _isDead;
        set
        {
            if (_isDead != value)
            {
                _isDead = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

/// <summary>
/// Represents a player's position at a specific time for map display.
/// </summary>
public class PlayerPosition
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float Rotation { get; set; }
    public string PlayerName { get; set; } = string.Empty;
    public int TeamId { get; set; }
    public bool IsDead { get; set; }
}
