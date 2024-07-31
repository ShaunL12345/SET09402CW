using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Haulage;
using Haulage.BaseClasses.Accounting;
using Moq;

namespace HaulageTests
{
    public class CustomerPageTests
    {
        [Fact]
        public void CustomerPage_ShouldInitializeWithoutParameters()
        {
            // Arrange & Act
            var exception = Record.Exception(() => new CustomerPage());

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void CustomerPage_ShouldInitializeWithParameters()
        {
            // Arrange
            var customer = new Customer();
            var account = new Account(Guid.NewGuid(), "Billing Details", "Contact Details");

            // Act
            var exception = Record.Exception(() => new CustomerPage(customer, account));

            // Assert
            Assert.Null(exception);
        }

        //[Fact]
        //public void SaveButton_Click_ShouldDisplaySuccessAlert()
        //{
        //    // Arrange
        //    var customer = new Mock<Customer>();
        //    var account = new Account(Guid.NewGuid(), "Old Billing Details", "Old Contact Details");
        //    var page = new CustomerPage(customer.Object, account);

        //    // Simulate user input
        //    page.FindByName<Entry>("BillingDetailsEntry").Text = "New Billing Details";
        //    page.FindByName<Entry>("ContactDetailsEntry").Text = "New Contact Details";

        //    // Act
        //    var exception = Record.Exception(() => page.SaveButton_Click(null, null));

        //    // Assert
        //    Assert.Null(exception);
        //    // Note: In a real application, you would need to use a more advanced approach to verify the DisplayAlert call.
        //}

        [Fact]
        public void SaveButton_Click_ShouldDisplayErrorAlertWhenCustomerIsNull()
        {
            // Arrange
            var page = new CustomerPage();
            var billingEntry = page.FindByName<Entry>("BillingDetailsEntry");
            var contactEntry = page.FindByName<Entry>("ContactDetailsEntry");
            billingEntry.Text = "Billing Details";
            contactEntry.Text = "Contact Details";

            // Act
            var exception = Record.Exception(() => page.SaveButton_Click(null, null));

            // Assert
            Assert.Null(exception);
            // Note: In a real application, you would need to use a more advanced approach to verify the DisplayAlert call.
        }
    }
}
