// Ignore Spelling: App

using System.Windows;
using HarvestHollow.LevelEditor.Views;

namespace HarvestHollow.LevelEditor;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        MainWindow mainWindow = new();
        mainWindow.Show();
    }
    private static void s_appDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        // Log the exception and show a message to the user
        MessageBox.Show("An error occurred: " + e.Exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        e.Handled = true; // Prevent default unhandled exception processing
    }
}
