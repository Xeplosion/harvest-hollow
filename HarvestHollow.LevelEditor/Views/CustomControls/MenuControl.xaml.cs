using System;
using System.Windows.Controls;
using HarvestHollow.LevelEditor.ViewModels;

namespace HarvestHollow.LevelEditor.Views.CustomControls;

/// <summary>
/// Interaction logic for MenuControl.xaml
/// </summary>
public partial class MenuControl : UserControl
{
    public MenuControl()
    {
        InitializeComponent();
        this.DataContext = new MenuControlViewModel();
    }
}
