using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PavlovReplayViewer;

/// <summary>
/// A custom WPF control for rendering a 2D map of player positions.
/// </summary>
public class Player2DMapControl : Canvas
{
    private const double DefaultMapSize = 10000; // Typical UE map size in units
    private const double PlayerIconSize = 16;
    private const double PlayerDirectionLength = 20;
    private const int MaxTrailLength = 100; // Number of position history points to keep
    
    private readonly Dictionary<string, List<PlayerPosition>> _playerTrails = new();
    private readonly Dictionary<string, UIElement> _playerElements = new();
    private readonly List<Line> _trailLines = new();
    private readonly List<UIElement> _gridLines = new();
    private readonly Dictionary<string, bool> _playerWasDeadLastFrame = new();
    private double _currentMinX, _currentMaxX, _currentMinY, _currentMaxY;
    private double _targetMinX, _targetMaxX, _targetMinY, _targetMaxY;
    private bool _isFirstUpdate = true;
    private bool _needsFullRedraw = true;
    private readonly DispatcherTimer _renderTimer;
    private bool _isRendering = false;

    public static readonly DependencyProperty PlayerPositionsProperty =
        DependencyProperty.Register(
            nameof(PlayerPositions),
            typeof(ObservableCollection<PlayerPosition>),
            typeof(Player2DMapControl),
            new PropertyMetadata(null, OnPlayerPositionsChanged));

    public ObservableCollection<PlayerPosition>? PlayerPositions
    {
        get => (ObservableCollection<PlayerPosition>?)GetValue(PlayerPositionsProperty);
        set => SetValue(PlayerPositionsProperty, value);
    }

    public void ClearTrails()
    {
        _playerTrails.Clear();
        _playerWasDeadLastFrame.Clear();
        _needsFullRedraw = true;
    }

    public Player2DMapControl()
    {
        // Throttle rendering to 30 FPS for better performance
        _renderTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(33) // ~30 FPS
        };
        _renderTimer.Tick += (s, e) => UpdateMapIfNeeded();
    }

    private static void OnPlayerPositionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is Player2DMapControl control)
        {
            if (e.OldValue is ObservableCollection<PlayerPosition> oldCollection)
            {
                oldCollection.CollectionChanged -= control.PlayerPositions_CollectionChanged;
            }

            if (e.NewValue is ObservableCollection<PlayerPosition> newCollection)
            {
                newCollection.CollectionChanged += control.PlayerPositions_CollectionChanged;
            }

            control._needsFullRedraw = true;
            if (!control._renderTimer.IsEnabled)
            {
                control._renderTimer.Start();
            }
        }
    }

    private void PlayerPositions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        _needsFullRedraw = true;
        if (!_renderTimer.IsEnabled)
        {
            _renderTimer.Start();
        }
    }

    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);
        _needsFullRedraw = true;
        UpdateMapIfNeeded();
    }

    private void UpdateMapIfNeeded()
    {
        if (_isRendering || !_needsFullRedraw) return;
        
        _isRendering = true;
        try
        {
            UpdateMap();
            _needsFullRedraw = false;
        }
        finally
        {
            _isRendering = false;
        }
    }

    private void UpdateMap()
    {
        if (PlayerPositions == null || PlayerPositions.Count == 0)
        {
            Children.Clear();
            _playerTrails.Clear();
            _playerElements.Clear();
            _trailLines.Clear();
            _gridLines.Clear();
            DrawNoDataMessage();
            return;
        }

        // Update player trails with current positions
        UpdatePlayerTrails();

        // Calculate bounds and scale with smooth interpolation
        var (minX, maxX, minY, maxY) = CalculateBounds();
        
        if (_isFirstUpdate)
        {
            _currentMinX = _targetMinX = minX;
            _currentMaxX = _targetMaxX = maxX;
            _currentMinY = _targetMinY = minY;
            _currentMaxY = _targetMaxY = maxY;
            _isFirstUpdate = false;
        }
        else
        {
            // Smoothly interpolate bounds
            _targetMinX = minX;
            _targetMaxX = maxX;
            _targetMinY = minY;
            _targetMaxY = maxY;
            
            const double smoothing = 0.15; // Lower = smoother but slower
            _currentMinX += (_targetMinX - _currentMinX) * smoothing;
            _currentMaxX += (_targetMaxX - _currentMaxX) * smoothing;
            _currentMinY += (_targetMinY - _currentMinY) * smoothing;
            _currentMaxY += (_targetMaxY - _currentMaxY) * smoothing;
        }
        
        var scale = CalculateScale(_currentMinX, _currentMaxX, _currentMinY, _currentMaxY);
        var offsetX = -_currentMinX * scale + 20;
        var offsetY = -_currentMinY * scale + 20;

        // Clear and redraw efficiently
        Children.Clear();
        
        // Draw grid background
        DrawGrid();

        // Draw player trails
        DrawPlayerTrails(scale, offsetX, offsetY);

        // Draw players
        foreach (var player in PlayerPositions)
        {
            DrawPlayer(player, scale, offsetX, offsetY);
        }

        // Draw legend
        DrawLegend();
    }
    
    private void UpdatePlayerTrails()
    {
        if (PlayerPositions == null) return;
        
        foreach (var player in PlayerPositions)
        {
            var key = $"{player.PlayerName}_{player.TeamId}";
            
            // Check if player was dead last frame
            bool wasDeadLastFrame = _playerWasDeadLastFrame.GetValueOrDefault(key, false);
            
            // If player just died or just respawned, start a new trail segment
            if (player.IsDead != wasDeadLastFrame)
            {
                // Clear this player's trail when they die or respawn
                if (_playerTrails.ContainsKey(key))
                {
                    _playerTrails[key].Clear();
                }
                _playerWasDeadLastFrame[key] = player.IsDead;
            }
            
            // Don't add trail points for dead players
            if (player.IsDead)
            {
                continue;
            }
            
            if (!_playerTrails.ContainsKey(key))
            {
                _playerTrails[key] = new List<PlayerPosition>();
            }
            
            var trail = _playerTrails[key];
            
            // Only add if position has changed significantly (at least 10 units)
            bool shouldAdd = true;
            if (trail.Count > 0)
            {
                var lastPos = trail[trail.Count - 1];
                var distance = Math.Sqrt(
                    Math.Pow(player.X - lastPos.X, 2) + 
                    Math.Pow(player.Y - lastPos.Y, 2));
                shouldAdd = distance > 10; // Minimum distance threshold
            }
            
            if (shouldAdd)
            {
                // Add current position to trail (create a copy)
                trail.Add(new PlayerPosition
                {
                    X = player.X,
                    Y = player.Y,
                    Z = player.Z,
                    PlayerName = player.PlayerName,
                    TeamId = player.TeamId,
                    IsDead = player.IsDead
                });
                
                // Remove old positions
                if (trail.Count > MaxTrailLength)
                {
                    trail.RemoveAt(0);
                }
            }
        }
    }
    
    private void DrawPlayerTrails(double scale, double offsetX, double offsetY)
    {
        foreach (var kvp in _playerTrails)
        {
            var trail = kvp.Value;
            if (trail.Count < 2) continue;
            
            var teamColor = GetTeamColor(trail[0].TeamId);
            
            // Draw trail as a series of connected lines with fading opacity
            for (int i = 0; i < trail.Count - 1; i++)
            {
                var pos1 = trail[i];
                var pos2 = trail[i + 1];
                
                var screenX1 = pos1.X * scale + offsetX;
                var screenY1 = ActualHeight - (pos1.Y * scale + offsetY);
                var screenX2 = pos2.X * scale + offsetX;
                var screenY2 = ActualHeight - (pos2.Y * scale + offsetY);
                
                // Calculate opacity based on position in trail (older = more transparent)
                var opacity = (double)(i + 1) / trail.Count * 0.6;
                var thickness = 1.5 + (double)(i + 1) / trail.Count * 2.0;
                
                var line = new Line
                {
                    X1 = screenX1,
                    Y1 = screenY1,
                    X2 = screenX2,
                    Y2 = screenY2,
                    Stroke = new SolidColorBrush(teamColor) { Opacity = opacity },
                    StrokeThickness = thickness,
                    StrokeLineJoin = PenLineJoin.Round,
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round
                };
                
                Children.Add(line);
            }
        }
    }

    private void DrawGrid()
    {
        var gridBrush = new SolidColorBrush(Color.FromArgb(20, 255, 255, 255));
        var gridSize = 50.0;

        for (double x = 0; x < ActualWidth; x += gridSize)
        {
            var line = new Line
            {
                X1 = x,
                Y1 = 0,
                X2 = x,
                Y2 = ActualHeight,
                Stroke = gridBrush,
                StrokeThickness = 1
            };
            Children.Add(line);
        }

        for (double y = 0; y < ActualHeight; y += gridSize)
        {
            var line = new Line
            {
                X1 = 0,
                Y1 = y,
                X2 = ActualWidth,
                Y2 = y,
                Stroke = gridBrush,
                StrokeThickness = 1
            };
            Children.Add(line);
        }
    }

    private (double minX, double maxX, double minY, double maxY) CalculateBounds()
    {
        if (PlayerPositions == null || PlayerPositions.Count == 0)
            return (-DefaultMapSize / 2, DefaultMapSize / 2, -DefaultMapSize / 2, DefaultMapSize / 2);

        var positions = PlayerPositions.Where(p => !p.IsDead).ToList();
        if (positions.Count == 0)
            positions = PlayerPositions.ToList(); // Include dead players if all are dead

        var minX = positions.Min(p => p.X);
        var maxX = positions.Max(p => p.X);
        var minY = positions.Min(p => p.Y);
        var maxY = positions.Max(p => p.Y);

        // Add padding
        var paddingX = Math.Max((maxX - minX) * 0.2, 1000);
        var paddingY = Math.Max((maxY - minY) * 0.2, 1000);

        return (minX - paddingX, maxX + paddingX, minY - paddingY, maxY + paddingY);
    }

    private double CalculateScale(double minX, double maxX, double minY, double maxY)
    {
        var mapWidth = maxX - minX;
        var mapHeight = maxY - minY;

        var availableWidth = ActualWidth - 40;
        var availableHeight = ActualHeight - 40;

        var scaleX = availableWidth / mapWidth;
        var scaleY = availableHeight / mapHeight;

        return Math.Min(scaleX, scaleY);
    }

    private void DrawPlayer(PlayerPosition player, double scale, double offsetX, double offsetY)
    {
        // Convert world coordinates to screen coordinates
        // In UE, Y is forward, X is right, so we map X to screen X and Y to screen Y (inverted)
        var screenX = player.X * scale + offsetX;
        var screenY = ActualHeight - (player.Y * scale + offsetY); // Invert Y for screen coords

        var teamColor = GetTeamColor(player.TeamId);
        var opacity = player.IsDead ? 0.3 : 1.0;

        // Draw player circle
        var circle = new Ellipse
        {
            Width = PlayerIconSize,
            Height = PlayerIconSize,
            Fill = new SolidColorBrush(teamColor) { Opacity = opacity },
            Stroke = Brushes.White,
            StrokeThickness = 2
        };

        SetLeft(circle, screenX - PlayerIconSize / 2);
        SetTop(circle, screenY - PlayerIconSize / 2);
        Children.Add(circle);

        // Draw direction indicator
        var rotation = player.Rotation;
        var radians = rotation * Math.PI / 180.0;
        var endX = screenX + Math.Cos(radians) * PlayerDirectionLength;
        var endY = screenY - Math.Sin(radians) * PlayerDirectionLength; // Negative because screen Y is inverted

        var directionLine = new Line
        {
            X1 = screenX,
            Y1 = screenY,
            X2 = endX,
            Y2 = endY,
            Stroke = new SolidColorBrush(teamColor) { Opacity = opacity },
            StrokeThickness = 2
        };
        Children.Add(directionLine);

        // Draw player name
        var nameText = new TextBlock
        {
            Text = player.PlayerName,
            Foreground = new SolidColorBrush(Colors.White) { Opacity = opacity },
            FontSize = 10,
            FontWeight = FontWeights.Bold
        };

        SetLeft(nameText, screenX + PlayerIconSize / 2 + 5);
        SetTop(nameText, screenY - 5);
        Children.Add(nameText);

        // Draw X if dead
        if (player.IsDead)
        {
            var deadMark1 = new Line
            {
                X1 = screenX - 8,
                Y1 = screenY - 8,
                X2 = screenX + 8,
                Y2 = screenY + 8,
                Stroke = Brushes.Red,
                StrokeThickness = 3
            };
            Children.Add(deadMark1);

            var deadMark2 = new Line
            {
                X1 = screenX + 8,
                Y1 = screenY - 8,
                X2 = screenX - 8,
                Y2 = screenY + 8,
                Stroke = Brushes.Red,
                StrokeThickness = 3
            };
            Children.Add(deadMark2);
        }
    }

    private void DrawLegend()
    {
        var legendX = 10.0;
        var legendY = 10.0;

        // Background
        var legendBg = new Rectangle
        {
            Width = 150,
            Height = 80,
            Fill = new SolidColorBrush(Color.FromArgb(220, 30, 30, 30)),
            Stroke = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255)),
            StrokeThickness = 1
        };
        SetLeft(legendBg, legendX);
        SetTop(legendBg, legendY);
        Children.Add(legendBg);

        // Title
        var title = new TextBlock
        {
            Text = "Teams",
            Foreground = Brushes.White,
            FontWeight = FontWeights.Bold,
            FontSize = 12
        };
        SetLeft(title, legendX + 10);
        SetTop(title, legendY + 5);
        Children.Add(title);

        // Team 0
        DrawLegendItem("Team 0", GetTeamColor(0), legendX + 10, legendY + 25);
        
        // Team 1
        DrawLegendItem("Team 1", GetTeamColor(1), legendX + 10, legendY + 45);

        // Dead indicator
        var deadText = new TextBlock
        {
            Text = "✕ = Dead",
            Foreground = Brushes.Red,
            FontSize = 10,
            FontWeight = FontWeights.Bold
        };
        SetLeft(deadText, legendX + 10);
        SetTop(deadText, legendY + 65);
        Children.Add(deadText);
    }

    private void DrawLegendItem(string label, Color color, double x, double y)
    {
        var circle = new Ellipse
        {
            Width = 12,
            Height = 12,
            Fill = new SolidColorBrush(color),
            Stroke = Brushes.White,
            StrokeThickness = 1
        };
        SetLeft(circle, x);
        SetTop(circle, y);
        Children.Add(circle);

        var text = new TextBlock
        {
            Text = label,
            Foreground = Brushes.White,
            FontSize = 10
        };
        SetLeft(text, x + 20);
        SetTop(text, y - 2);
        Children.Add(text);
    }

    private void DrawNoDataMessage()
    {
        var message = new TextBlock
        {
            Text = "No replay data loaded.\nOpen a replay file to view player positions.",
            Foreground = new SolidColorBrush(Color.FromArgb(128, 200, 200, 200)),
            FontSize = 16,
            TextAlignment = TextAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center
        };

        SetLeft(message, ActualWidth / 2 - 150);
        SetTop(message, ActualHeight / 2 - 20);
        Children.Add(message);
    }

    private static Color GetTeamColor(int teamId)
    {
        return teamId switch
        {
            0 => Colors.Blue,
            1 => Colors.Red,
            2 => Colors.Green,
            3 => Colors.Yellow,
            _ => Colors.Gray
        };
    }
}
