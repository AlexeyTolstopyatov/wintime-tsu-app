using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace WinTime.Model;

/// <summary>
/// InTimeObject model contains Key and Name of building,
/// which stores on a server-side of TSU
/// </summary>
public class InTimeObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private string? _name;
    private string? _id;

    /// <summary>
    /// Ident of InTimeObject on a TSU server-side
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id
    {
        get => _id;
        private set => SetField(ref _id, value, nameof(Id));
    }
    
    /// <summary>
    /// Name of building
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name
    {
        get => _name;
        private set => SetField(ref _name, value, nameof(Name));
    }

    /// <summary>
    /// Make the InTimeObject Instance
    /// </summary>
    /// <param name="id">Server-side key of InTimeObject</param>
    /// <param name="name">Human-recognizable value</param>
    public InTimeObject(string id, string name)
    {
        Id = id;
        Name = name;
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