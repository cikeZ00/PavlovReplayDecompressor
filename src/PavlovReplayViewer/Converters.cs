using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace PavlovReplayViewer;

/// <summary>
/// Converts a double representing seconds to a time span string.
/// </summary>
public class TimeSpanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double seconds)
        {
            var timeSpan = TimeSpan.FromSeconds(seconds);
            
            if (timeSpan.TotalHours >= 1)
            {
                return timeSpan.ToString(@"h\:mm\:ss");
            }
            else
            {
                return timeSpan.ToString(@"mm\:ss");
            }
        }

        return "00:00";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string str && TimeSpan.TryParse(str, out var timeSpan))
        {
            return timeSpan.TotalSeconds;
        }

        return 0.0;
    }
}

/// <summary>
/// Converts a team ID to a color brush.
/// </summary>
public class TeamColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int teamId)
        {
            var color = teamId switch
            {
                0 => Colors.Blue,
                1 => Colors.Red,
                2 => Colors.Green,
                3 => Colors.Yellow,
                _ => Colors.Gray
            };

            return new SolidColorBrush(color);
        }

        return new SolidColorBrush(Colors.Gray);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Converts a boolean to a Visibility value.
/// </summary>
public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Visibility visibility)
        {
            return visibility == Visibility.Visible;
        }

        return false;
    }
}
