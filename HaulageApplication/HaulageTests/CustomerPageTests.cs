using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Haulage;
using Haulage.BaseClasses.Accounting;

namespace HaulageTests
{
    public class CustomerPageTests
    {
        private Customer _customer;
        private Account _account;
        private CustomerPage _customerPage;

        public CustomerPageTests()
        {
            _customer = new Customer();
            _account = new Account(Guid.NewGuid(), "Billing Info", "Contact Info");
            _customerPage = new CustomerPage(_customer, _account);
        }

        [Fact]
        public void CustomerPage_ShouldDisplayAccountDetails()
        {
            // Assert
            Assert.Equal("Billing Info", _customerPage.FindByName<Entry>("BillingDetailsEntry").Text);
            Assert.Equal("Contact Info", _customerPage.FindByName<Entry>("ContactDetailsEntry").Text);
        }

        [Fact]
        public void SaveButton_Click_ShouldUpdateAccountDetails()
        {
            // Arrange
            var billingEntry = _customerPage.FindByName<Entry>("BillingDetailsEntry");
            var contactEntry = _customerPage.FindByName<Entry>("ContactDetailsEntry");

            billingEntry.Text = "New Billing Info";
            contactEntry.Text = "New Contact Info";

            // Act
            _customerPage.SaveButton_Click(null, null);

            // Assert
            Assert.Equal("New Billing Info", _account.BillingDetails);
            Assert.Equal("New Contact Info", _account.ContactDetails);
        }
    }
}
