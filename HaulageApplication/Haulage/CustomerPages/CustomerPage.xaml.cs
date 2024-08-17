using Haulage.BillviewModel;
using SQLite;
using System.Runtime.CompilerServices;
using Haulage.CustomerPages;
using Haulage.BaseClasses.Accounting;
namespace Haulage;

public partial class CustomerPage : ContentPage
{

    private Customer _customer;
    private Account _account;
    public CustomerPage()
	{
		InitializeComponent();

        //Button ManageBilling = FindByName("ManageBilling") as Button;
        //ManageBilling.Clicked += async (sender, args) => { await Navigation.PushAsync(new ManageBillingPage()); };
    }

   private void ManageBilling_Clicked(object sender, EventArgs e)
    {

        Button ManageBilling = FindByName("ManageBilling") as Button;
        ManageBilling.Clicked += async (sender, args) => { await Navigation.PushAsync(new ManageBillingPage()); };
    }

    private async void CustomerTrackItemNavigationButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CustomerPages.TrackItemPage());

    }

    public CustomerPage(Customer customer, Account account)
    {
        InitializeComponent();
        _customer = customer ?? throw new ArgumentNullException(nameof(customer));
        _account = account ?? throw new ArgumentNullException(nameof(account));

        // Initialize the entries
        BillingDetailsEntry.Text = account.BillingDetails;
        ContactDetailsEntry.Text = account.ContactDetails;
    }

    public void SaveButton_Click(object sender, EventArgs e)
    {
        if (_customer != null && _account != null)
        {
            _customer.ManageAccount(_account, BillingDetailsEntry.Text, ContactDetailsEntry.Text);
            DisplayAlert("Success", "Account details updated successfully.", "OK");
        }
        else
        {
            DisplayAlert("Error", "Failed to update account details.", "OK");
        }

    }

    private void ManageBilling_Clicked_1(object sender, EventArgs e)
    {

    }
}