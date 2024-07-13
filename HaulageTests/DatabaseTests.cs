using System;
using System.IO;
using Xunit;
using SQLite;

namespace HaulageTests
{
    public static class DatabaseSetup
    {
        private static string _databasePath;
        public static SQLiteConnection Connection => new SQLiteConnection(_databasePath);

        public static void SetDatabasePath(string path)
        {
            _databasePath = path;
        }

        public static void InitializeDatabase()
        {
            if (!File.Exists(_databasePath))
            {
                using (var connection = Connection)
                {
                    connection.CreateTable<User>();
                }
            }
        }

        public class User
        {
            [PrimaryKey, AutoIncrement]
            public int UserID { get; set; }
            public int RoleID { get; set; }
            public string FullName { get; set; }
        }
    }

    public class DatabaseSetupTests : IDisposable
    {
        private readonly string _testDbPath;

        public DatabaseSetupTests()
        {
            // Use a unique test database path to avoid conflicts
            _testDbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestHaulage.db");
            DatabaseSetup.SetDatabasePath(_testDbPath);

            // Ensure a clean state before each test
            if (File.Exists(_testDbPath))
            {
                File.Delete(_testDbPath);
            }
        }

        [Fact]
        public void TestDatabaseIsCreatedIfNotExists()
        {
            // Initialize the database
            DatabaseSetup.InitializeDatabase();

            // Check that the database file was created
            Assert.True(File.Exists(_testDbPath));
        }

        [Fact]
        public void TestUsersTableIsCreated()
        {
            // Initialize the database (this will also create the file if it doesn't exist)
            DatabaseSetup.InitializeDatabase();

            // Verify the Users table was created
            using (var connection = DatabaseSetup.Connection)
            {
                var tableInfo = connection.GetTableInfo("User");
                Assert.NotEmpty(tableInfo);
            }
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
