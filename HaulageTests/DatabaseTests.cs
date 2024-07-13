using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using SQLite;
using HaulageTests;

namespace HaulageTests
{
    [TestClass]
    public class DatabaseSetupTests
    {
        private string _testDbPath;

        [TestInitialize]
        public void Setup()
        {
            // Use a unique test database path to avoid conflicts
            _testDbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestHaulage.db");
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up the test database file after each test
            if (File.Exists(_testDbPath))
            {
                File.Delete(_testDbPath);
            }
        }

        //[TestMethod]
        //public void TestDatabaseIsCreatedIfNotExists()
        //{
        //    // Ensure the database file does not exist before the test
        //    if (File.Exists(_testDbPath))
        //    {
        //        File.Delete(_testDbPath);
        //    }

        //    // Initialize the database
        //    DatabaseSetup.InitializeDatabase();

        //    // Check that the database file was created
        //    Assert.IsTrue(File.Exists(_testDbPath));
        //}

        //[TestMethod]
        //public void TestUsersTableIsCreated()
        //{
        //    // Initialize the database (this will also create the file if it doesn't exist)
        //    DatabaseSetup.InitializeDatabase();

        //    // Verify the Users table was created
        //        using (var connection = new SQLiteConnection(GetDatabasePath()))
        //        {

        //        string query = "SELECT name FROM sqlite_master WHERE type='table' AND name='users';";

        //        var command = new SQLite.SQLiteCommand(connection);
        //        command.CommandText = query;
        //        var result = command.ExecuteNonQuery();
        //        Assert.IsNotNull(result);
        //        //        Assert.AreEqual("users", result);
        //       // result.

        //        }
            
        //}
    }

   //// public static class DatabaseSetup
   // {
   //     private static string _databasePath;
   //     public static string ConnectionString => $"Data Source={_databasePath};Version=3;";

   //     public static void SetDatabasePath(string path)
   //     {
   //         _databasePath = path;
   //     }

      
   // }
}
