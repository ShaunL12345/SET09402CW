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
    public class VehicleTest
    {
        private SQLiteConnection GetInMemoryConnection()
        {
            var connection = new SQLiteConnection(":memory:");
            return connection;
        }


        [Fact]
        public void GetVehiclesFromDatabse()
        {
            var connection = GetInMemoryConnection();
            DatabaseSetup.InitializeDatabase();
            DatabaseSetup.CreateTables(connection);
            DatabaseSetup.GenerateData(connection);
            var vehicles = VehicleExecutionService.GetVehicles(connection);
            Assert.NotNull(vehicles);
            Assert.True(vehicles.Count > 0,"Did not recieve any records from GetVehicles method");
        }
        [Fact]
        public void DeleteVehicleFromDatabse()
        {
            var connection = GetInMemoryConnection();

            DatabaseSetup.InitializeDatabase();
            DatabaseSetup.CreateTables(connection);
            DatabaseSetup.GenerateData(connection);
            var vehicles = VehicleExecutionService.GetVehicles(connection);

            var vehicleToRemove = vehicles.First();
            var initialVehicleCount = vehicles.Count;
            VehicleExecutionService.DeleteVehicle(vehicleToRemove.VehicleId,connection);
            var vehicleCountAfter = VehicleExecutionService.GetVehicles(connection).Count;
            Assert.True(vehicleCountAfter == initialVehicleCount - 1, "Failed to delete a vehicle record");
        }
        [Fact]
        public void SaveVehicleToDatabse()
        {
            var connection = GetInMemoryConnection();
            DatabaseSetup.InitializeDatabase();
            DatabaseSetup.CreateTables(connection);
            DatabaseSetup.GenerateData(connection);
            var vehiclesCountBefore = VehicleExecutionService.GetVehicles(connection).Count;

            Vehicle vehicle = new Vehicle()
            {
                VehicleId = 132321,
                tripID = 4321321,
                Capacity = 123321,
                DriverId = 321213,
                LicensePlate = "ASD23HF",
                Status = Vehicle.StatusType.TestEnum1
            };
            VehicleExecutionService.SaveVehicle(vehicle,connection);
            var vehiclesCountAfter = VehicleExecutionService.GetVehicles(connection).Count;
            Assert.True(vehiclesCountAfter== vehiclesCountBefore+1, "VehiclesRecord was not saved");
        }
    }
}
