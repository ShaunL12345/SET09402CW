using System;
using System.IO;
using Xunit;
using SQLite;
using Haulage.DatabaseExecutionServices;
using Haulage.Models;
using Haulage.BaseClasses.Accounting;

namespace HaulageTests
{
    /// <summary>
    /// 
    /// </summary>
    public class VehicleTest : IDisposable
    {
        private readonly string _testDbPath;
        private SQLiteConnection GetInMemoryConnection()
        {
            var connection = new SQLiteConnection(":memory:");
            return connection;
        }
        [Fact]
        public void TestVehiclesRetrievedByModel()
        {

            var Vehicles = VehicleModel.vehicles;
        }

        [Fact]
        public void GetVehiclesFromDatabse()
        {
            DatabaseSetup.InitializeDatabase();
            var vehicles = VehicleExecutionService.GetVehicles();
            Assert.NotNull(vehicles);
            Assert.True(vehicles.Count > 0,"Did not recieve any records from GetVehicles method");
        }
        [Fact]
        public void DeleteVehicleFromDatabse()
        {
            //DatabaseSetup.InitializeDatabase();
            //var vehicle = new Vehicle() 
            //{

            //}

            //Assert.True(vehicles.Count > 0, "Did not recieve any records from GetVehicles method");
        }
        [Fact]
        public void SaveVehicleToDatabse()
        {
            DatabaseSetup.InitializeDatabase();
            var vehicles = VehicleExecutionService.GetVehicles();
            Assert.NotNull(vehicles);
            Assert.True(vehicles.Count > 0, "Did not recieve any records from GetVehicles method");
        }

        public void Dispose()
        {
            // Clean up the test database file after each test
            if (File.Exists(_testDbPath))
            {
                File.Delete(_testDbPath);
            }
        }
    }
}
