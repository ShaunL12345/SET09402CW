using Haulage.BaseClasses.Accounting;
using System;
using Microsoft.Maui.Controls;

namespace Haulage;

public partial class CustomerPage : ContentPage
{
    //private Customer _customer;
    //private Account _account;

    //public CustomerPage(Customer customer, Account account)
    //{
    //    InitializeComponent();
    //    _customer = customer;
    //    _account = account;

    //    // Initialize the entries
    //    BillingDetailsEntry.Text = account.BillingDetails;
    //    ContactDetailsEntry.Text = account.ContactDetails;
    //}

    public void SaveButton_Click(object sender, EventArgs e)
    {
        //_customer.ManageAccount(_account, BillingDetailsEntry.Text, ContactDetailsEntry.Text);
    }

    public CustomerPage()
    {
        InitializeComponent();
    }
}