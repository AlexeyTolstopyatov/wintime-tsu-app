using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Baml2006;
using MicaWPF.Core.Interop;
using WinTime.Model;

namespace WinTime.Driver;

/// <summary>
/// Represents API for InTime server
/// I try to implement InTime API here.
/// <see href="https://miniapps.intime.tsu.ru/docs/docs/libraries/tsu-intime-bridge/"/>>
/// </summary>
public class InTimeDriver
{
    private static InTimeDriver? DriverInstance { get; set; }
    
    /// <summary>
    /// Singleton pattern usage, just because
    /// Only one instance of TSU API driver needed
    /// </summary>
    /// <returns>
    /// A Main instance of driver
    /// </returns>
    public static InTimeDriver Call()
    {
        return DriverInstance ??= new InTimeDriver();
    }

    /// <summary>
    /// Creates Http GET request and
    /// deserializes JSON response message
    /// </summary>
    /// <param name="collection">Pointer to InTimeObject's collection</param>
    /// <param name="path">InTime server's endpoint (don't set full API address)</param>
    /// <typeparam name="T">Type of Collection, derived from List of InTime Objects</typeparam>
    /// <returns>Filled collection by pointer</returns>
    /// <seealso cref="InTimeObject"/>
    /// <seealso cref="ObservableCollection{T}"/>
    public InTimeDriver Deserialize<T>(ref T collection, string path) where T : ObservableCollection<InTimeObject>
    {
        HttpClient client = new();
        try
        {
            var request = 
                client.GetAsync("https://intime.tsu.ru/api/old-web/v1/" + path);
            
            request.Result.EnsureSuccessStatusCode();

            var response = 
                request.Result.Content.ReadFromJsonAsync<T>();
            
            if (response.Result is not null)
                collection = response.Result;
            
        }
        catch (Exception e)
        {
            NotificationDriver
                .Call()
                .Notify("WinTime errors occured", e.Message);
        }

        return this;
    }
}