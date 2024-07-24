namespace Haulage;

using Haulage.BaseClasses.Accounting;
using System;
using Microsoft.Maui.Controls;

public partial class App : Application
{
    public static INavigationService NavigationService { get; private set; }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        NavigationService = new NavigationService();
    }
}

public interface INavigationService
{
    Task NavigateToCustomerPage(Customer customer, Account account);
}

public class NavigationService : INavigationService
{
    public Task NavigateToCustomerPage(Customer customer, Account account)
    {
        var customerPage = new CustomerPage(customer, account);
        return Shell.Current.Navigation.PushAsync(customerPage);
    }
}