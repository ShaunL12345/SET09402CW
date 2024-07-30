using Haulage.DriverPages;
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
}

    


