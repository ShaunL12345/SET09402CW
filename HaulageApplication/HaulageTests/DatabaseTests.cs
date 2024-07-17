using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Haulage;

namespace HaulageTests
{
    public class DatabaseSetupTests : IDisposable
    {
        private const string TestDatabasePath = "TestHaulage.db";

        public DatabaseSetupTests()
        {
            // Remove the test database file if it exists
            if (File.Exists(TestDatabasePath))
            {
                File.Delete(TestDatabasePath);
            }

            // Create an empty test database file
            using (var connection = new SQLiteConnection(TestDatabasePath))
            {
                connection.CreateTable<User>();
                connection.CreateTable<Vehicle>();
                connection.CreateTable<Role>();
                connection.CreateTable<Trip>();
                connection.CreateTable<Item>();
                connection.CreateTable<Bill>();
                connection.CreateTable<Event>();
                connection.CreateTable<Expense>();
                connection.CreateTable<TripManifest>();
            }
        }

        [Fact]
        public void TestInitializeDatabase_CreatesAndPopulatesTables()
        {
            // Arrange
            var originalDatabasePath = DatabaseSetup.GetDatabasePath();
            var backupDatabasePath = originalDatabasePath + ".backup";

            if (File.Exists(originalDatabasePath))
            {
                File.Copy(originalDatabasePath, backupDatabasePath, true);
            }

            try
            {
                // Act
                DatabaseSetup.InitializeDatabase();

                // Assert
                using (var connection = new SQLiteConnection(originalDatabasePath))
                {
                    var vehicles = connection.Table<Vehicle>().ToList();
                    Assert.Equal(3, vehicles.Count);
                    Assert.Equal("test1", vehicles[0].LicensePlate);
                    Assert.Equal("test2", vehicles[1].LicensePlate);
                    Assert.Equal("test3", vehicles[2].LicensePlate);
                }
            }
            finally
            {
                if (File.Exists(backupDatabasePath))
                {
                    File.Copy(backupDatabasePath, originalDatabasePath, true);
                    File.Delete(backupDatabasePath);
                }
            }
        }

        public void Dispose()
        {
            // Remove the test database file after each test
            if (File.Exists(TestDatabasePath))
            {
                File.Delete(TestDatabasePath);
            }
        }

        // Define dummy classes for the tables used in your tests
        public class User
        {
            public int UserID { get; set; }
            public int RoleID { get; set; }
            public string FullName { get; set; }
        }

        public class Vehicle
        {
            public int VehicleId { get; set; }
            public int TripID { get; set; }
            public string LicensePlate { get; set; }
            public int Capacity { get; set; }
            public int DriverId { get; set; }
            public int Status { get; set; }
        }

        public class Role
        {
            public int RoleId { get; set; }
            public string RoleDesc { get; set; } // Renamed property to avoid conflict
            public string FullName { get; set; }
        }

        public class Trip
        {
            public int TripId { get; set; }
            public string StartLocation { get; set; }
            public string EndLocation { get; set; }
        }

        public class Item
        {
            public int ItemID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Bill
        {
            public int BillId { get; set; }
            public string Fullname { get; set; }
            public string Email { get; set; }
        }

        public class Event
        {
            public int EventId { get; set; }
            public int DriverId { get; set; }
        }

        public class Expense
        {
            public int ExpenseId { get; set; }
            public int DriverId { get; set; }
            public int VehicleId { get; set; }
        }

        public class TripManifest
        {
            public int ManifestId { get; set; }
            public int TripId { get; set; }
            public int PickUpRequest { get; set; }
        }
    }
}
