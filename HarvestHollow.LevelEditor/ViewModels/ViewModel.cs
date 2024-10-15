using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HarvestHollow.LevelEditor.ViewModels;

/// <summary>
/// Base class for view models implementing the <see cref="INotifyPropertyChanged"/> interface.
/// </summary>
/// <remarks>
/// The <see cref="ViewModel"/> class provides functionality for property change notifications,
/// allowing WPF controls to update automatically when the underlying data changes.
/// </remarks>
public class ViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// Occurs when a property changes.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Raises the <see cref="PropertyChanged"/> event for the specified property name.
    /// </summary>
    /// <param name="propertyName">The name of the property that changed. 
    /// This parameter is optional and can be automatically provided by the compiler.</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
