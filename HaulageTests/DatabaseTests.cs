using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SQLite;
using System.IO;

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
            DatabaseSetup.SetDatabasePath(_testDbPath);
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

        [TestMethod]
        public void TestDatabaseIsCreatedIfNotExists()
        {
            // Ensure the database file does not exist before the test
            if (File.Exists(_testDbPath))
            {
                File.Delete(_testDbPath);
            }

            // Initialize the database
            DatabaseSetup.InitializeDatabase();

            // Check that the database file was created
            Assert.IsTrue(File.Exists(_testDbPath));
        }

        [TestMethod]
        public void TestUsersTableIsCreated()
        {
            // Initialize the database (this will also create the file if it doesn't exist)
            DatabaseSetup.InitializeDatabase();

            // Verify the Users table was created
            using (var connection = new SQLiteConnection(DatabaseSetup.ConnectionString))
            {
                connection.Open();
                string query = "SELECT name FROM sqlite_master WHERE type='table' AND name='users';";
                using (var command = new SQLiteCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    Assert.IsNotNull(result);
                    Assert.AreEqual("users", result);
                }
            }
        }
    }

    public static class DatabaseSetup
    {
        private static string _databasePath;
        public static string ConnectionString => $"Data Source={_databasePath};Version=3;";

        public static void SetDatabasePath(string path)
        {
            _databasePath = path;
        }

        public static void InitializeDatabase()
        {
            if (!File.Exists(_databasePath))
            {
                SQLiteConnection.CreateFile(_databasePath);

                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    string createUsersTableQuery = @"
                        CREATE TABLE IF NOT EXISTS users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoleID INTEGER NOT NULL,
                        FullName TEXT NOT NULL
                        );";

                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = createUsersTableQuery;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
