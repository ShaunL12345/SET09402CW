using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

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
            string testDatabasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TestDatabasePath);
            DatabaseSetup.SetDatabasePath(testDatabasePath);

            // Act
            DatabaseSetup.InitializeDatabase();

            // Assert
            using (var connection = new SQLiteConnection(testDatabasePath))
            {
                var vehicles = connection.Table<Vehicle>().ToList();
                Assert.Equal(3, vehicles.Count);
                Assert.Equal("test1", vehicles[0].LicensePlate);
                Assert.Equal("test2", vehicles[1].LicensePlate);
                Assert.Equal("test3", vehicles[2].LicensePlate);
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

    public static class DatabaseSetup
    {
        private static string databasePath = "Haulage.db";

        public static void SetDatabasePath(string path)
        {
            databasePath = path;
        }

        public static string GetDatabasePath()
        {
            return databasePath;
        }

        public static void InitializeDatabase()
        {
            if (File.Exists(GetDatabasePath()))
            {
                using (var connection = new SQLiteConnection(GetDatabasePath()))
                {
                    DropTables(connection);
                    CreateTables(connection);
                    GenerateData(connection);
                }
            }
        }

        public static void DropTables(SQLiteConnection connection)
        {
            List<string> dropTableScripts = new List<string>
            {
                "DROP TABLE IF EXISTS [User]",
                "DROP TABLE IF EXISTS [Bill]",
                "DROP TABLE IF EXISTS [Event]",
                "DROP TABLE IF EXISTS [Expense]",
                "DROP TABLE IF EXISTS [Item]",
                "DROP TABLE IF EXISTS [Role]",
                "DROP TABLE IF EXISTS [Trip]",
                "DROP TABLE IF EXISTS [TripManifest]",
                "DROP TABLE IF EXISTS [Vehicle]"
            };

            foreach (string table in dropTableScripts)
            {
                var command = new SQLiteCommand(connection) { CommandText = table };
                command.ExecuteNonQuery();
            }
        }

        private static void GenerateData(SQLiteConnection connection)
        {
            // Vehicle data
            CreateVehicles(connection);
        }

        private static void CreateVehicles(SQLiteConnection connection)
        {
            List<string> dataScripts = new List<string>
            {
                @"INSERT INTO [Vehicle] ([VehicleId], [tripID], [LicensePlate], [Capacity], [DriverId], [Status]) VALUES (1, 1, 'test1', 1, 1,1);",
                @"INSERT INTO [Vehicle] ([VehicleId], [tripID], [LicensePlate], [Capacity], [DriverId], [Status]) VALUES (2, 2, 'test2', 2, 2,1);",
                @"INSERT INTO [Vehicle] ([VehicleId], [tripID], [LicensePlate], [Capacity], [DriverId], [Status]) VALUES (3, 3, 'test3', 3, 3,3);"
            };

            foreach (string tableScript in dataScripts)
            {
                var command = new SQLiteCommand(connection) { CommandText = tableScript };
                command.ExecuteNonQuery();
            }
        }

        private static void CreateTables(SQLiteConnection connection)
        {
            List<string> createTableScripts = new List<string>
            {
                @"CREATE TABLE IF NOT EXISTS [User] (UserID INTEGER PRIMARY KEY AUTOINCREMENT, RoleID INTEGER NOT NULL, FullName TEXT NOT NULL);",
                @"CREATE TABLE IF NOT EXISTS [Item] (ItemID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Description TEXT NOT NULL);",
                @"CREATE TABLE IF NOT EXISTS [Trip] (TripId INTEGER PRIMARY KEY AUTOINCREMENT, StartLocation TEXT NOT NULL, EndLocation TEXT NOT NULL);",
                @"CREATE TABLE IF NOT EXISTS [Role] (RoleId INTEGER PRIMARY KEY AUTOINCREMENT, RoleDesc TEXT NOT NULL, FullName TEXT NOT NULL);",
                @"CREATE TABLE IF NOT EXISTS [Vehicle] (VehicleId INTEGER PRIMARY KEY AUTOINCREMENT, TripID INTEGER, LicensePlate TEXT UNIQUE NOT NULL, Capacity INTEGER NOT NULL, DriverId INTEGER NOT NULL, Status INTEGER NOT NULL);",
                @"CREATE TABLE IF NOT EXISTS [TripManifest] (ManifestId INTEGER PRIMARY KEY AUTOINCREMENT, TripId INTEGER NOT NULL, PickUpRequest INTEGER NOT NULL);",
                @"CREATE TABLE IF NOT EXISTS [Bill] (BillId INTEGER PRIMARY KEY AUTOINCREMENT, Fullname TEXT NOT NULL, Email TEXT NOT NULL);",
                @"CREATE TABLE IF NOT EXISTS [Expense] (ExpenseId INTEGER PRIMARY KEY AUTOINCREMENT, DriverId INTEGER NOT NULL, VehicleId INTEGER NOT NULL);",
                @"CREATE TABLE IF NOT EXISTS [Event] (EventId INTEGER PRIMARY KEY AUTOINCREMENT, DriverId INTEGER NOT NULL);"
            };

            foreach (string tableScript in createTableScripts)
            {
                var command = new SQLiteCommand(connection) { CommandText = tableScript };
                command.ExecuteNonQuery();
            }
        }
    }
}
