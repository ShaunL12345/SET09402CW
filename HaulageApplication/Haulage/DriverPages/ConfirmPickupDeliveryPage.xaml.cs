namespace Haulage.DriverPages;
using Haulage.BaseClasses.TripHandler;
using Haulage.DatabaseExecutionServices;
using Haulage.Models;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

public partial class ConfirmPickupDeliveryPage : ContentPage
{
	public ConfirmPickupDeliveryPage()
	{
		InitializeComponent();
	}

    private void PickedUpItemButton_Clicked(object sender, EventArgs e)
    {
        if (validEntry())
        {
            try 
            {
                ItemModel.pickupItem(Int32.Parse(itemIDEntry.Text.Trim()));
                DisplayAlert("Success", "Vehicle details updated successfully.", "OK");
            }
            catch 
            {
                DisplayAlert("Error", $"Failed to update item status", "OK");
            }

        }
        else
        {
            DisplayAlert("Error", $"Failed to parse entry.", "OK");
        }
    }

    private void DropOffItemButton_Clicked(object sender, EventArgs e)
    {
        if (validEntry())
        {
            try
            {
                ItemModel.dropOffItem(Int32.Parse(itemIDEntry.Text.Trim()));
                DisplayAlert("Success", "Vehicle details updated successfully.", "OK");
            }
            catch 
            {
                DisplayAlert("Error", $"Failed to update item status", "OK");
            }
        }
        else
        {
            DisplayAlert("Error", $"Failed to parse entry.", "OK");
        }
    }

    private bool validEntry() 
    {
        if (!string.IsNullOrEmpty(itemIDEntry.Text))
        {
            var userId = itemIDEntry.Text.Trim();

            if (Int32.TryParse(userId, out var parsedID)) return true;
            else return false;
        }
        else
        {
            return false;
        }
    }


}