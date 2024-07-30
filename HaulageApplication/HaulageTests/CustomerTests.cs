using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Haulage.BaseClasses.Accounting;
using System;

namespace HaulageTests
{
    [CollectionDefinition("DatabaseTests", DisableParallelization = true)]
    public class CustomerTests
    {
        private Customer _customer;

        public CustomerTests()
        {
            _customer = new Customer();
        }

        [Fact]
        public void ManageAccount_ShouldUpdateAccountDetails()
        {
            // Arrange
            var personID = Guid.NewGuid();
            var account = new Account(personID, "Old Billing Info", "Old Contact Info");

            // Act
            _customer.ManageAccount(account, "New Billing Info", "New Contact Info");

            // Assert
            Assert.Equal("New Billing Info", account.BillingDetails);
            Assert.Equal("New Contact Info", account.ContactDetails);
        }
    }
}
