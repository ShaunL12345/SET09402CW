namespace Haulage;
using Haulage.BaseClasses.Accounting;
using System;

public partial class CustomerPage : ContentPage
{
    private Customer _customer;
    private Account _account;

    public CustomerPage(Customer customer, Account account)
    {
        InitializeComponent();
        _customer = customer;
        _account = account;

        BillingDetailsEntry.Text = _account.BillingDetails;
        ContactDetailsEntry.Text = _account.ContactDetails;
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        _customer.ManageAccount(_account, BillingDetailsEntry.Text, ContactDetailsEntry.Text);
        DisplayAlert("Success", "Account details updated successfully.", "OK");
    }
}