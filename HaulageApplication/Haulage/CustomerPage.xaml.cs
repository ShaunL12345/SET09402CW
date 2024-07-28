namespace Haulage;

public partial class CustomerPage : ContentPage
{
	public CustomerPage()
	{
		InitializeComponent();
	}

    private async void CustomerTrackItemNavigationButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CustomerPages.TrackItemPage());
    }
}