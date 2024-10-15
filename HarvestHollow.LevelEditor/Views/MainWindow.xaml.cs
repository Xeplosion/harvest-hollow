using System.Windows;
using HarvestHollow.LevelEditor.ViewModels;

namespace HarvestHollow.LevelEditor.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainWindowViewModel();
    }
}
