namespace Haulage.DriverPages;
using Haulage.BaseClasses.TripHandler;
using Haulage.DatabaseExecutionServices;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

public partial class DriverRaiseEventPage : ContentPage
{
	public DriverRaiseEventPage()
	{
		InitializeComponent();
	}

    private void SaveTripEvent_Clicked(object sender, EventArgs e)
    {


        (string status, string message, string button) =  raiseEvent(DriverIdEntry, TripIdEntry, EventTypeEntry, DescriptionEntry);
        DisplayAlert(status, message, button);
    }

    

    public static (string, string, string) raiseEvent(Entry DriverIdEntry,
                                    Entry TripIdEntry,
                                    Entry EventTypeEntry,
                                    Entry DescriptionEntry
         )
    {
        try
        {
            TripEvent raisedEvent = new TripEvent()
            {
                DriverId = Int32.Parse(DriverIdEntry.Text),
                TripId = Int32.Parse(TripIdEntry.Text),
                EventType = (TripEvent.Eventtype)Int32.Parse(EventTypeEntry.Text),
                Description = DescriptionEntry.Text
            };
            DriverExecutionService.RaiseEvent(raisedEvent);

            DriverIdEntry.Text = "";
            TripIdEntry.Text = "";
            EventTypeEntry.Text = "";
            DescriptionEntry.Text = "";
            return ("Success", "Vehicle details updated successfully.", "OK");
        }
        catch (Exception)
        {
            return ("Error", $"Failed to update Vehicle details.", "OK");
        }
    }
}