using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Haulage.BaseClasses.Accounting;
using System;
using Moq;
using Haulage.DatabaseExecutionServices;
using Haulage.viewModels;
using Haulage;
using Haulage.AdminPages;
using Haulage.ViewModels;
namespace HaulageTests
{
    [CollectionDefinition("DatabaseTests", DisableParallelization = true)]
    public class CustomerTests
    {
        [Fact]
        public void GetCustomersFromDatabse()
        {
            DatabaseSetup.InitializeDatabase();
            var customers = CustomerExecutionService.GetCustomers();
            Assert.NotNull(customers);
            Assert.True(customers.Count > 0, "Did not recieve any records from getCustomers method");
        }

        [Fact]
        public void DeleteCustomersFromDatabse()
        {

            DatabaseSetup.InitializeDatabase();
            var customers = CustomerExecutionService.GetCustomers();

            var customerToRemove = customers.First();
            var initialCustomerCount = customers.Count;
            CustomerExecutionService.deleteCustomer(customerToRemove.UserId);
            var customerCountAfter = CustomerExecutionService.GetCustomers().Count;
            Assert.True(customerCountAfter == initialCustomerCount - 1, "Failed to delete a customer record");
        }

        [Fact]
        public void SaveVehicleToDatabse()
        {
            DatabaseSetup.InitializeDatabase();
            var vehiclesCountBefore = CustomerExecutionService.GetCustomers().Count;
            var customer = new Customer()
            {
                UserId = 1234567,
                Fullname ="Test user",
                Email="Test@testemail",
                PhoneNumber= "123455676",
                UserRole = Role.customer,
                Address = "TestAddress"
            };
            CustomerExecutionService.SaveCustomer(customer);
            var vehiclesCountAfter = CustomerExecutionService.GetCustomers().Count;
            Assert.True(vehiclesCountAfter == vehiclesCountBefore + 1, "customer record was not saved");
        }

        [Fact]
        public void GetCustomerViewModel()
        {
            DatabaseSetup.InitializeDatabase();

            var model = new CustomerViewModel();
            Assert.NotNull(model);
            Assert.True(model.Customers.Count > 0);
        }
    }
}
