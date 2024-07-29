namespace Haulage;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
        InitializeComponent();

        Button ManageEmployees = FindByName("ManageEmployees") as Button;
        ManageEmployees.Clicked += async (sender, args) => { await Navigation.PushAsync(new ManageEmployees()); };

	}

    private void ManageEmployees_Clicked(object sender, EventArgs e)
    {

    }
}