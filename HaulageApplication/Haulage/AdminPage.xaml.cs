using Haulage.AdminPages;

namespace Haulage;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
        InitializeComponent();

	}
    private void ManageEmployees_Clicked(object sender, EventArgs e)
    {
        Button ManageEmployees = FindByName("ManageEmployees") as Button;
        ManageEmployees.Clicked += async (sender, args) => { await Navigation.PushAsync(new ManageEmployees()); };
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