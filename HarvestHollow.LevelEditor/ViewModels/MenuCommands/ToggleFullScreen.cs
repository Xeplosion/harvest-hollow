using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using HarvestHollow.LevelEditor.ViewModels;
using HarvestHollow.LevelEditor.Views;

namespace HarvestHollow.LevelEditor.ViewModels.MenuCommands;

public static class ToggleFullScreen
{
    /// <summary>
    /// Toggles the fullscreen state of the main window.
    /// </summary>
    /// <param name="viewModel">The instance of the MenuControlViewModel.</param>
    public static void s_Toggle()
    {
        var window = Application.Current.MainWindow;
        bool isFullscreen = MainWindow.s_IsFullscreen;

        if (isFullscreen)
        {
            window.WindowStyle = WindowStyle.ThreeDBorderWindow;
            window.WindowState = WindowState.Normal;
            window.ResizeMode = ResizeMode.CanResize;
        }
        else
        {
            window.WindowStyle = WindowStyle.SingleBorderWindow; 
            window.WindowState = WindowState.Maximized; 
            window.ResizeMode = ResizeMode.NoResize;
        }

        // Update the ViewModel's fullscreen property
        MenuControlViewModel.s_MenuIsFullscreen = !isFullscreen;
        MainWindow.s_IsFullscreen = !isFullscreen;
    }
}