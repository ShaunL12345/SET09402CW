namespace Haulage;

using Haulage.BaseClasses.Accounting;
using System;
using Microsoft.Maui.Controls;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(CustomerPage), typeof(CustomerPage));
    }

    private async void OnCustomerMenuItemClicked(object sender, EventArgs e)
    {
        var customer = new Customer();
        var account = new Account
        {
            BillingDetails = "Test Billing Details",
            ContactDetails = "Test Contact Details"
        };

        await App.NavigationService.NavigateToCustomerPage(customer, account);
    }
}
