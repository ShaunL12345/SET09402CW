namespace Haulage.DriverPages;
using Haulage.BaseClasses.TripHandler;
using Haulage.DatabaseExecutionServices;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

public partial class ConfirmPickupDeliveryPage : ContentPage
{
	public ConfirmPickupDeliveryPage()
	{
		InitializeComponent();
	}

    //private void SaveTripEvent_Clicked(object sender, EventArgs e)
    //{


    //    (string status, string message, string button) =  raiseEvent(DriverIdEntry, TripIdEntry, EventTypeEntry, DescriptionEntry);
    //    DisplayAlert(status, message, button);
    //}
}