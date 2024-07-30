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
namespace HaulageTests
{
    [CollectionDefinition("databaseTests", DisableParallelization = true)]
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
        public void GetVehicleViewModel()
        {
            DatabaseSetup.InitializeDatabase();

            var model = new VehicleViewModel();
            Assert.NotNull(model);
            Assert.True(model.Vehicles.Count > 0);
        }

        //[Fact]
        //public void save_customerInPage()
        //{
        //    DatabaseSetup.InitializeDatabase();
        //    // Arrange
        //    var customer = new Customer()
        //    {
        //        UserId = 1234567,
        //        Fullname = "Test user",
        //        Email = "Test@testemail",
        //        PhoneNumber = "123455676",
        //        UserRole = Role.customer,
        //        Address = "TestAddress"
        //    };
            
        //    // Act
        //    var page = new ManageCustomerPage();
        //    page.FindByName<Entry>("EntryCustomerId").Text = "1";
        //    var button = page.FindByName<Button>("DeleteCustomer");

        //    var vehiclesCountBefore = CustomerExecutionService.GetCustomers().Count;

        //    page.DeleteCustomer_Clicked(null,null);

        //    var vehiclesCountAfter = CustomerExecutionService.GetCustomers().Count;

        //    Assert.True(vehiclesCountAfter == vehiclesCountAfter - 1);

        //    // Assert
        //}
    }
}
