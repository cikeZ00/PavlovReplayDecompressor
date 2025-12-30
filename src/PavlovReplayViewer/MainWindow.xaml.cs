using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace PavlovReplayViewer;

public partial class MainWindow : Window
{
    private readonly ReplayPlayerViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        _viewModel = new ReplayPlayerViewModel();
        _viewModel.ClearTrailsRequested += (s, e) => MapControl.ClearTrails();
        DataContext = _viewModel;
    }

    private void OpenReplay_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Replay files (*.replay)|*.replay|All files (*.*)|*.*",
            Title = "Select a Pavlov replay file"
        };

        if (dialog.ShowDialog() == true)
        {
            try
            {
                _viewModel.LoadReplay(dialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading replay: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void Timeline_DragStarted(object sender, DragStartedEventArgs e)
    {
        _viewModel.PauseForSeek();
    }

    private void Timeline_DragCompleted(object sender, DragCompletedEventArgs e)
    {
        _viewModel.ResumeFromSeek();
    }

    protected override void OnClosed(EventArgs e)
    {
        _viewModel.Dispose();
        base.OnClosed(e);
    }
}
