using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using HarvestHollow.LevelEditor.Utilities;

namespace HarvestHollow.LevelEditor.ViewModels.MenuCommands;

/// <summary>
/// A command that closes the application when executed.
/// </summary>
/// <remarks>
/// The <see cref="QuitApplication"/> class implements the ICommand interface,
/// allowing it to be bound to a UI element for quitting the application.
/// </remarks>
public class QuitApplication : ICommand
{
    /// <summary>
    /// Occurs when the ability of this command to execute changes.
    /// </summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// Determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">Data used by the command, if any. This parameter is not used in this implementation.</param>
    /// <returns>true if the command can execute; otherwise, false.</returns>
    public bool CanExecute(object? parameter)
    {
        // This determines whether the command is enabled. 
        // If you always want the application to be able to close, return true.
        return true;
    }

    /// <summary>
    /// Executes the command to close the application.
    /// </summary>
    /// <param name="parameter">Data used by the command, if any. This parameter is not used in this implementation.</param>
    public void Execute(object? parameter)
    {
        // Close the application
        Debug.WriteLine("Quitting application");
        Application.Current.Shutdown();
    }

    /// <summary>
    /// Raises the <see cref="CanExecuteChanged"/> event to re-evaluate if the command can execute.
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
