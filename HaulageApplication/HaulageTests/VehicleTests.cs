using System;
using System.IO;
using Xunit;
using SQLite;
using Haulage.DatabaseExecutionServices;
using Haulage.Models;
using Haulage.BaseClasses.Accounting;
using Haulage.viewModels;
using Haulage.AdminPages;
namespace HaulageTests
{

    /// <summary>
    /// 
    /// </summary>
    [CollectionDefinition("DatabaseTests", DisableParallelization = true)]
    public class VehicleTest
    {
        [Fact]
        public void GetVehiclesFromDatabse()
        {
            DatabaseSetup.InitializeDatabase();
            var vehicles = VehicleExecutionService.GetVehicles();
            Assert.NotNull(vehicles);
            Assert.True(vehicles.Count > 0, "Did not recieve any records from GetVehicles method");
        }
        //[Fact]
        //public void DeleteVehicleFromDatabse()
        //{

        //    DatabaseSetup.InitializeDatabase();

        //    var vehicles = VehicleExecutionService.GetVehicles();

        //    var vehicleToRemove = vehicles.First();
        //    var initialVehicleCount = vehicles.Count;
        //    VehicleExecutionService.DeleteVehicle(vehicleToRemove.VehicleId);
        //    var vehicleCountAfter = VehicleExecutionService.GetVehicles().Count;
        //    Assert.True(vehicleCountAfter == initialVehicleCount - 1, "Failed to delete a vehicle record");
        //}
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
                Status = Vehicle.StatusType.onroute
            };
            VehicleExecutionService.SaveVehicle(vehicle);
            var vehiclesCountAfter = VehicleExecutionService.GetVehicles().Count;
            Assert.True(vehiclesCountAfter == vehiclesCountBefore + 1, "VehiclesRecord was not saved");
        }
        [Fact]
        public void GetVehicleViewModel()
        {
            DatabaseSetup.InitializeDatabase();

            var model = new VehicleViewModel();
            Assert.NotNull(model);
            Assert.True(model.Vehicles.Count > 0);
        }
    }
}
