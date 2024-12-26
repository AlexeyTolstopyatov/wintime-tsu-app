using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using WinTime.Driver;
using Wpf.Ui.Abstractions.Controls;

namespace WinTime.View;

public partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Gets ID of selected Faculty based on MainPage view model.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FacultiesList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    { 
        if (DataContext is ViewModel.MainPage vm)
        {
            // Index of Faculty in ContentElement and
            // Index of Faculty in Collection are the same 
            string? key = vm
                .Faculties
                .Where(f => f.Name == vm.Faculties[FacultiesList.SelectedIndex].Name)
                .Select(f => f.Id)
                .FirstOrDefault();
            
            if (string.IsNullOrEmpty(key))
            {
                NotificationDriver.Call().Notify(
                    "TSU InTime Driver Middleware", 
                    "Key of Faculty undefined. You need to restart Application.");
            }
            
            NavigationService!.Navigate(new GroupsPage());
        } 
        else 
        {
            NotificationDriver
                .Call()
                .Notify(
                    "WinTime Modeling",
                    "Type of DataContext is invalid");
        }
    }
}