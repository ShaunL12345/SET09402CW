using Haulage;
using Haulage.DatabaseExecutionServices;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Haulage.DatabaseExecutionServices;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;


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
        public void GetEmployeesFromDatabse()
        {
            //Arrange
            var connection = GetInMemoryConnection();
            DatabaseSetup.InitializeDatabase();
            DatabaseSetup.CreateTables(connection);
            DatabaseSetup.GenerateData(connection);

            //Act
            var drivers = UserExecutionService.GetDrivers(connection);

            //Assert
            Assert.NotNull(drivers);
            Assert.True(drivers.Count > 0, "Did not recieve any records from GetDrivers method");


        }

        //[Fact]

        //public void DeleteDmployeeFromDatabse()
        //{
        //    //Arrange
        //    var connection = GetInMemoryConnection();
        //    DatabaseSetup.InitializeDatabase();
        //    DatabaseSetup.CreateTables(connection);
        //    DatabaseSetup.GenerateData(connection);

        //    //Act
        //    var drivers = UserExecutionService.GetDrivers(connection);
        //    var driverToRemove = drivers.First();
        //    var initialDriverCount = drivers.Count;
        //    UserExecutionService.DeleteDriver(driverToRemove.UserId, connection);
        //    var DriverCountAfter = UserExecutionService.GetDrivers(connection).Count;

        //    //Assert
        //    Assert.True(DriverCountAfter == initialDriverCount - 1, "Failed to delete a employee record");
        //}

        
    }
}
