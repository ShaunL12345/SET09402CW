namespace Haulage;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
		InitializeComponent();
	}
    private async void VehiclesNavigationButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ManageVehiclesPage()); 
    }
}