using System;
using System.Windows.Input;

namespace HarvestHollow.LevelEditor.Utilities;

/// <summary>
/// Represents a command that can be executed and determines if it can be executed.
/// </summary>
/// <remarks>
/// The <see cref="RelayCommand"/> class is useful for implementing the ICommand interface,
/// enabling the binding of command logic to UI elements in a WPF application.
/// </remarks>
internal class RelayCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;

    /// <summary>
    /// Initializes a new instance of the <see cref="RelayCommand"/> class.
    /// </summary>
    /// <param name="execute">The action to execute when the command is invoked.</param>
    /// <param name="canExecute">A function that determines whether the command can execute.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="execute"/> is null.</exception>
    public RelayCommand(Action execute, Func<bool> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    /// <summary>
    /// Determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">Data used by the command, if any. This parameter is not used in this implementation.</param>
    /// <returns>true if the command can execute; otherwise, false.</returns>
    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute();
    }

    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="parameter">Data used by the command, if any. This parameter is not used in this implementation.</param>
    public void Execute(object? parameter)
    {
        _execute();
    }

    /// <summary>
    /// Occurs when the ability of this command to execute changes.
    /// </summary>
    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}



