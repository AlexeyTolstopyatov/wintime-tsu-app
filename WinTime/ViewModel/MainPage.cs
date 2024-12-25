using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WinTime.Driver;
using WinTime.Model;

namespace WinTime.ViewModel;

public class MainPage : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly BuildingsCollection _buildings;
    private readonly FacultiesCollection _faculties;
    public BuildingsCollection Buildings
    {
        get => _buildings;
        private init => SetField(ref _buildings, value);
    }

    public FacultiesCollection Faculties
    {
        get => _faculties;
        private init => SetField(ref _faculties, value);
    }
    
    public MainPage()
    {
        BuildingsCollection buildings = Buildings;
        FacultiesCollection faculties = Faculties;
        InTimeDriver
            .Call()
            .Deserialize(ref buildings, "buildings")
            .Deserialize(ref faculties, "faculties");

        Buildings = buildings;
        Faculties = faculties;
    }
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}