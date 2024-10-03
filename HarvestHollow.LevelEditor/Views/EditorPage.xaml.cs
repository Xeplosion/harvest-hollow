using HarvestHollow.LevelEditor.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace HarvestHollow.LevelEditor.Views;

public sealed partial class EditorPage : Page
{
    public EditorViewModel ViewModel
    {
        get;
    }

    public EditorPage()
    {
        ViewModel = App.GetService<EditorViewModel>();
        InitializeComponent();
    }
}
