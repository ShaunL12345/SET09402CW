using Haulage.BaseClasses.Accounting;
using System;
using Microsoft.Maui.Controls;
using Haulage.ViewModels;

namespace Haulage;

public partial class CustomerPage : ContentPage
{
    private Customer _customer;
    private Account _account;

    public CustomerPage()
    {
        InitializeComponent();
        BindingContext = new CustomerViewModel();
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

}