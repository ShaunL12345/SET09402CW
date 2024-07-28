using Haulage;
using Haulage.DatabaseExecutionServices;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Haulage.BaseClasses.Accounting;


namespace HaulageTests
{
    public class AdministratorTests
    {
        private SQLiteConnection GetInMemoryConnection()
        {
            var connection = new SQLiteConnection(":memory:");
            return connection;
        }


        [Fact]
        public void GetDriversFromDatabase()
        {
            //Arrange
            var connection = GetInMemoryConnection();
            DatabaseSetup.InitializeDatabase();
            DatabaseSetup.CreateTables(connection);
            DatabaseSetup.GenerateData(connection);

            //Act
            var drivers = DriverExecutionService.GetDrivers(connection);

            //Assert
            Assert.NotNull(drivers);
            Assert.True(drivers.Count < 0, "Did not recieve any records from GetDrivers method");


        }

        [Fact]

        public void DeleteDriversFromDatabse()
        {
            //Arrange
            var connection = GetInMemoryConnection();
            DatabaseSetup.InitializeDatabase();
            DatabaseSetup.CreateTables(connection);
            DatabaseSetup.GenerateData(connection);

            //Act
            var drivers = DriverExecutionService.GetDrivers(connection);
            var driverToRemove = drivers.First();
            var initialDriverCount = drivers.Count;
            DriverExecutionService.DeleteDriver(driverToRemove.UserId, connection);
            var DriverCountAfter = DriverExecutionService.GetDrivers(connection).Count;

            //Assert
            Assert.True(DriverCountAfter == initialDriverCount - 1, "Failed to delete a employee record");
        }

        [Fact]

        public void SaveDriverInDatabase()
        {
            //Arrange
            var connection = GetInMemoryConnection();
            DatabaseSetup.InitializeDatabase();
            DatabaseSetup.CreateTables(connection);
            DatabaseSetup.GenerateData(connection);

            //Act
            var drivers = DriverExecutionService.GetDrivers(connection);
            var aNewDriver = new Driver(123456, "Aidan Gallagher", "aidan.gallagher@gmail.com", "12345 239387", Role.driver, "21 Test street", "fragile");
            var initialDriverCount = drivers.Count;
            DriverExecutionService.SaveDriver(aNewDriver);
            var DriverCountAfter = DriverExecutionService.GetDrivers(connection).Count;

            //Assert
            Assert.True(DriverCountAfter == initialDriverCount + 1, "Saved employee record successfully");
        





    }
        
    }
}
