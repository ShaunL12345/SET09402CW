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
            DatabaseSetup.InitializeDatabase();
            var vehicles = VehicleExecutionService.GetVehicles();
            var vehicleToRemove = vehicles.First();
            var initialVehicleCount = vehicles.Count;
            VehicleExecutionService.DeleteVehicle(vehicleToRemove.VehicleId); 

            Assert.True(initialVehicleCount == initialVehicleCount-1, "Failed to delete a vehicle record");
        }
        [Fact]
        public void SaveVehicleToDatabse()
        {
            DatabaseSetup.InitializeDatabase();
            var vehiclesCountBefore = VehicleExecutionService.GetVehicles().Count;

            Vehicle vehicle = new Vehicle()
            {
                VehicleId = 132321,
                tripID = 4321321,
                Capacity = 123321,
                DriverId = 321213,
                LicensePlate = "ASD23HF",
                Status = Vehicle.StatusType.TestEnum1
            };
            VehicleExecutionService.SaveVehicle(vehicle);
            var vehiclesCountAfter = VehicleExecutionService.GetVehicles().Count;
            Assert.True(vehiclesCountAfter== vehiclesCountBefore+1, "VehiclesRecord was not saved");
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
