using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using WinTime.Driver;
using WinTime.Model;

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
        // FIXME: Follow the MVVM pattern. Rewrite all logic in ViewModel ware.
        if (DataContext is ViewModel.MainPage vm)
        {
            string? key = vm
                .Faculties
                .Where(f => f.Name == vm.Faculties[FacultiesList.SelectedIndex].Name)
                .Select(f => f.Id)
                .FirstOrDefault(); 
            
            if (string.IsNullOrEmpty(key))
            {
                NotificationDriver
                    .Call()
                    .Notify(
                    "TSU InTime Driver Middleware", 
                    "Key of Faculty undefined. You need to restart Application.");
                
                return;
            }
            string groupsQuery = $"faculties/{key}/groups";
            
            GroupsCollection groups = new();
            InTimeDriver
                .Call()
                .Deserialize(ref groups, groupsQuery);

            vm.Groups = groups;
            vm.SelectedFaculty = vm.Faculties[FacultiesList.SelectedIndex].Name!;
            
            NavigationService!.Navigate(new GroupsPage{DataContext = vm});
        }
        else 
        {
            // If DataContext casting fails, All specific fields will stand null-contained
            // or unavailable. [null-contained] objects usage is denied.
            #if DEBUG
            NotificationDriver
                .Call()
                .Notify(
                    "TSU InTime Driver Middleware",
                    "DataContext casting failed.");
            #endif
        }
    }
}