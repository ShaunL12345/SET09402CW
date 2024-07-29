using Haulage.BaseClasses.Accounting;
using System;
using Microsoft.Maui.Controls;

namespace Haulage;

public partial class CustomerPage : ContentPage
{
    private Customer _customer;
    private Account _account;

    public CustomerPage()
    {
        InitializeComponent();
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
}