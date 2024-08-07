using Haulage.BaseClasses.Accounting;
using Haulage.DatabaseExecutionServices;
using SQLite;

namespace Haulage.AdminPages;

public partial class AddVehiclePage : ContentPage
{
	public AddVehiclePage()
	{
		InitializeComponent();
	}

    private void SaveVehicle_Clicked(object sender, EventArgs e)
    {
        try
        {
            Vehicle vehicle = new Vehicle()
            {
                VehicleId = Int32.Parse(VehicleIdEntry.Text),
                tripID = Int32.Parse(tripIDEntry.Text),
                Capacity = Int32.Parse(CapacityEntry.Text),
                DriverId = Int32.Parse(DriverIdEntry.Text),
                LicensePlate = LicensePlateEntry.Text,
                Status = Enum.Parse<Vehicle.StatusType>(StatusEntry.Text.ToLower())
            };
            VehicleExecutionService.SaveVehicle(vehicle);

            VehicleIdEntry.Text = "";
            tripIDEntry.Text = "";
            CapacityEntry.Text = "";
            DriverIdEntry.Text = "";
            LicensePlateEntry.Text = "";
            DisplayAlert("Success", "Vehicle details updated successfully.", "OK");
            Console.WriteLine("Vehicle successfully Added");
        }
        catch (Exception) 
        {
            Console.WriteLine("Error saving data into the vehicle table");
            DisplayAlert("Error", $"Failed to update Vehicle details.", "OK");
        }
    }
}