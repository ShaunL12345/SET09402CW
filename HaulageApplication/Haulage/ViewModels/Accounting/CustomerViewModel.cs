using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Haulage.BaseClasses.Accounting;

namespace Haulage.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        private Customer _customer;
        private Account _account;

        public Customer Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        public Account Account
        {
            get => _account;
            set => SetProperty(ref _account, value);
        }

        public CustomerViewModel()
        {
            Customer = new Customer();  // Initialize with default or fetch from a service
            Account = new Account
            {
                BillingDetails = "Test Billing Details",
                ContactDetails = "Test Contact Details"
            };

            SaveChangesCommand = new Command(OnSaveChanges);
        }

        public ICommand SaveChangesCommand { get; }

        private void OnSaveChanges()
        {
            if (Account != null)
            {
                // Simulate saving the account details
                // You can add actual logic here to save to a database or an API call
                Console.WriteLine($"Billing Details: {Account.BillingDetails}");
                Console.WriteLine($"Contact Details: {Account.ContactDetails}");

                // Display a success message
                Application.Current.MainPage.DisplayAlert("Success", "Account details updated successfully.", "OK");
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Failed to update account details.", "OK");
            }
        }
    }
}
