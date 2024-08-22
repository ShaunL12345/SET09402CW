namespace Haulage;
using Haulage.DriverPages;
public partial class DriverPage : ContentPage
{
	public DriverPage()
	{
		InitializeComponent();
	}

    private async void DriverRaiseEventNavigationButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DriverRaiseEventPage());
    }
}