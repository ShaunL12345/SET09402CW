using Haulage.AdminPages;

namespace Haulage;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
        InitializeComponent();

	}
    private async void ManageEmployees_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ManageEmployeesPage());
    }

    private async void VehiclesNavigationButtonClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new ManageVehiclesPage()); 

    }

    private async void ManageCustomers_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ManageCustomerPage());
    }
}