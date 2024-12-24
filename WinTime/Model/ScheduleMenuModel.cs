using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinTime.Model;

public class ScheduleMenuModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public ScheduleMenuModel(string name)
    {
        Name = name;
    }
    
    public string? Name { get; set; }
    public string? Request { get; set; }
    
    #region INotifyPropertyChanged Internals
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) 
            return false;
        
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    #endregion
    
}