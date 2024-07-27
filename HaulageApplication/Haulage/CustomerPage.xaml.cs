namespace Haulage;

public partial class CustomerPage : ContentPage
{
	public CustomerPage()
	{
		InitializeComponent();
	}

    private async void CustomerNavigationButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CustomerPages.TrackItemPage());
    }
}