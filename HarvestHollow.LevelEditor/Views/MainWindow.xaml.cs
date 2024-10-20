using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using HarvestHollow.LevelEditor.ViewModels;
using HarvestHollow.LevelEditor.Views.SplitPanelControls;
using HarvestHollow.LevelEditor.Themes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace HarvestHollow.LevelEditor.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public static bool s_IsFullscreen { get; set; } = false;

    private static int _panel = 0;
    private static int _size = 1;
    private static int _index = 0;
    private static  int _count = 0;
    private static double _proportion = 0.5;
    private const int _numPanels = 6;
    private SplitPanel[] _panels = new SplitPanel[_numPanels];

    public MainWindow()
    {
        InitializeComponent();

        _panels[0] = panel1;
        _panels[1] = panel2;
        _panels[2] = panel3;
        _panels[3] = panel4;
        _panels[4] = panel5;
        _panels[5] = panel6;


        DataContext = new MainWindowViewModel();
    }
    private void toggleFullscreen_Click()
    {
        if (s_IsFullscreen)
        {
            WindowStyle = WindowStyle.ThreeDBorderWindow;
            WindowState = WindowState.Normal;
            ResizeMode = ResizeMode.CanResize;
        }
        else
        {
            WindowStyle = WindowStyle.SingleBorderWindow;
            WindowState = WindowState.Maximized;
            ResizeMode = ResizeMode.NoResize;
        }
        s_IsFullscreen = !s_IsFullscreen;
        MenuControlViewModel.s_MenuIsFullscreen = s_IsFullscreen;
    }
    private void splitPanel_FlipOrientation(object sender, RoutedEventArgs args)
    {
        SplitPanel panel = splitPanel_GetPanel();

        if (panel == null)
        {
            return;
        }

        panel.Orientation = ((panel.Orientation == Orientation.Horizontal) ? Orientation.Vertical : Orientation.Horizontal);
    }
    private void splitPanel_AddChild(object sender, RoutedEventArgs args)
    {
        SplitPanel panel = splitPanel_GetPanel();
        int index = s_splitPanel_GetIndex();
        double size = s_splitPanel_GetSize();

        if ((panel == null) || (index == -1) || (Double.IsNaN(size)) || (index > panel.Children.Count))
        {
            Debug.WriteLine("SplitPanel Error: Invalid Index!");
            return;
        }

        // Create a new child
        Border child = new Border();
        child.BorderBrush = Theme.CadetGray;
        child.Background = Theme.RichBlack;
        child.BorderThickness = new Thickness(1);

        SplitPanel.SetSize(child, size);

        panel.Children.Insert(index, child);
    }
    private void splitPanel_RemoveChild(object sender, RoutedEventArgs args)
    {
        SplitPanel panel = splitPanel_GetPanel();
        int index = s_splitPanel_GetIndex();

        if ((panel == null) || (index == -1) || (index > (panel.Children.Count - 1)))
        {
            Debug.WriteLine("SplitPanel Error: Invalid Index!");
            return;
        }

        // Get the child to remove
        UIElement child = panel.Children[index];

        if (child is SplitPanel)
        {
            Debug.WriteLine("SplitPanel Error: Cannot remove child split panel!");
            return;
        }

        // Remove the child
        panel.Children.RemoveAt(index);
    }
    private void splitPanel_SplitChild(object sender, RoutedEventArgs args)
    {
        SplitPanel panel = splitPanel_GetPanel();
        int index = s_splitPanel_GetIndex();
        double proportion = s_splitPanel_GetProportion();

        if ((panel == null) || (index == -1) || (index > (panel.Children.Count - 1)) || Double.IsNaN(proportion))
        {
            Debug.WriteLine("SplitPanel Error: Invalid Index!");
            return;
        }

        // Create a new child
        Border child = new Border();
        child.BorderBrush = Theme.CadetGray;
        child.Background = Theme.RichBlack;
        child.BorderThickness = new Thickness(1);

        panel.SplitChild(index, child, proportion);
    }
    private void splitPanel_CombineChildren(object sender, RoutedEventArgs args)
    {
        SplitPanel panel = splitPanel_GetPanel();
        int index = s_splitPanel_GetIndex();

        if ((panel == null) || (index < 0) || (_count == 0))
        {
            return;
        }


        int childInd = ((_count > 0) ? index : (index + _count));

        int lastInd = (childInd + Math.Abs(_count));

        if ((childInd < 0) || (lastInd >= panel.Children.Count))
        {
            Debug.WriteLine("SplitPanel Error: Invalid index!");
            Debug.WriteLine("SplitPanel Error: Invalid count!");
            return;
        }

        // Iterate through all the children
        for (int itrChildInd = childInd; itrChildInd < (lastInd + 1); itrChildInd++)
        {
            if (panel.Children[itrChildInd] is SplitPanel)
            {
                Debug.WriteLine("SplitPanel Error: Cannot combine child split panel!");
                Debug.WriteLine("SplitPanel Error: Cannot combine child split panel!");
                return;
            }
        }

        // Combine children
        panel.CombineChildren(index, _count);
    }
    private static int s_splitPanel_GetIndex()
    {
        int index = -1;

        try
        {
            if (_index >= 0 && _index < _numPanels)
            {
                index = _index;
            }
            else
            {
                Debug.WriteLine("SplitPanel Error: Invalid index!");
            }
        }
        catch
        {
            Debug.WriteLine("SplitPanel Error: Invalid index!");
        }

        return index;
    }
    private static double s_splitPanel_GetSize()
    {
        double size = Double.NaN;

        try
        {
            if ((_size >= 0) && !Double.IsInfinity(_size) && !Double.IsNaN(_size))
            {
                size = _size;
            }
            else
            {
                Debug.WriteLine("SplitPanel Error: Invalid size!");
            }
        }
        catch
        {
            Debug.WriteLine("SplitPanel Error: Invalid size!");
        }

        return size;
    }
    private static double s_splitPanel_GetProportion()
    {
        double proportion = Double.NaN;

        try
        {
            if ((_proportion >= -1) && !Double.IsInfinity(_proportion) && !Double.IsNaN(_proportion) && (_proportion <= 1))
            {
                proportion = _proportion;
            }
            else
            {
                Debug.WriteLine("SplitPanel Error: Invalid proportion!");
            }
        }
        catch
        {
            Debug.WriteLine("SplitPanel Error: Invalid proportion!");
        }

        return proportion;
    }
    private SplitPanel splitPanel_GetPanel()
    {
        int index = -1;

        try
        {
            if ((_panel >= 0) && (_panel < _numPanels))
            {
                index = _panel;
            }
            else
            {
                Debug.WriteLine("Invalid index!");
            }
        }
        catch
        {
            Debug.WriteLine("Invalid index!");
        }

        return ((index >= 0) ? _panels[index] : new SplitPanel());
    }
    private void window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        Debug.WriteLine(e.Key);
        if (e.Key == System.Windows.Input.Key.F11)
        {
            toggleFullscreen_Click();
            e.Handled = true;
        }
    }
}
