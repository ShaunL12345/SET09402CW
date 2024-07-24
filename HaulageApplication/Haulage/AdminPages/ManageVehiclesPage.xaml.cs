using Haulage.BaseClasses.Accounting;
using Haulage.DatabaseExecutionServices;
using Haulage.viewModel;
using Microsoft.Maui.Controls;
using Haulage.DatabaseExecutionServices;
using System.Collections.ObjectModel;
using System;
namespace Haulage;

public partial class ManageVehiclesPage : ContentPage
{

    public ManageVehiclesPage()
    {
        InitializeComponent();
    }
    private async void AddVehicle_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ManageVehiclesPage());
    }

    private void RemoveVehicle_Clicked(object sender, EventArgs e)
    {
        var vehicleId = entryId.Text.Trim();

        if (Int32.TryParse(vehicleId, out var parsedID)) VehicleExecutionService.DeleteVehicle(parsedID);
        else Console.WriteLine("Unable to parse value");
    }
}