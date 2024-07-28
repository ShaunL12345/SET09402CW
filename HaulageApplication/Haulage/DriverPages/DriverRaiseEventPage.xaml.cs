namespace Haulage.DriverPages;
using Haulage.BaseClasses.TripHandler;
using Haulage.DatabaseExecutionServices;
public partial class DriverRaiseEventPage : ContentPage
{
	public DriverRaiseEventPage()
	{
		InitializeComponent();
	}

    private void SaveTripEvent_Clicked(object sender, EventArgs e)
    {
        try
        {
            TripEvent evt = new TripEvent()
            {
                DriverId = Int32.Parse(DriverIdEntry.Text),
                TripId = Int32.Parse(TripIdEntry.Text),
                EventType = (TripEvent.Eventtype)Int32.Parse(EventTypeEntry.Text),
                Description = DriverIdEntry.Text
            };
            DriverExecutionService.RaiseEvent(evt);

            DriverIdEntry.Text = "";
            TripIdEntry.Text = "";
            EventTypeEntry.Text = "";
            DescriptionEntry.Text = "";
            DisplayAlert("Success", "Vehicle details updated successfully.", "OK");
        }
        catch (Exception)
        {
            DisplayAlert("Error", $"Failed to update Vehicle details.", "OK");
        }


    }
}