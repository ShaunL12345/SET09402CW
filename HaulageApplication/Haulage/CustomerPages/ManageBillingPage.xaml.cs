namespace Haulage;
using Haulage.CustomerPages;
public partial class ManageBillingPage : ContentPage
{
	public ManageBillingPage()
	{
		InitializeComponent();

        Button AddBills = FindByName("AddBills") as Button;
        AddBills.Clicked += async (sender, args) => { await Navigation.PushAsync(new AddBillsPage()); };
    }

    private void AddBills_Clicked(object sender, EventArgs e)
    {

    }

    private void DeleteBill_Clicked(object sender, EventArgs e)
    {

    }
}