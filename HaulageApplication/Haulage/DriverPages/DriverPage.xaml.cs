using Haulage.DriverPages;
using Microsoft.Maui.Controls;
namespace Haulage;

public partial class DriverPage : ContentPage
{
	public DriverPage()
	{
		InitializeComponent();
    }
    private void ManageExpensesPage_Clicked(object sender, EventArgs e)
    {
        ManageExpensesPage.Clicked += async (sender, args) => { await Navigation.PushAsync(new ManageExpensesPage()); };
    }
    private async void DriverRaiseEventNavigationButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DriverRaiseEventPage());
    }

    private async void pickup_delivery_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConfirmPickupDeliveryPage());
    }
}