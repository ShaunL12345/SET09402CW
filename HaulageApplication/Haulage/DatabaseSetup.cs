using SQLite;
using System.Data.SqlTypes;
using System.IO;
using System.Security.Cryptography.X509Certificates;


public static class DatabaseSetup
{
    public static string GetDatabasePath()
    {
        // Get the base directory of the application
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Combine the base directory with the relative path to the database
        string relativePath = Path.Combine(baseDirectory, @"..\..\..\..\..\Database\Haulage.db");

        // Resolve to a full absolute path
        return Path.GetFullPath(relativePath);
    }

    public static string connectionString = $"Data Source={GetDatabasePath()};Version=3;";


    public static void InitializeDatabase()
    {
        if (File.Exists($@"{GetDatabasePath()}"))
        {

            using (var connection = new SQLiteConnection(GetDatabasePath()))
            {
                List<string> createTableScripts = new List<string>();

                //Create User Table for Haulage Data;

                createTableScripts.Add(@"
                CREATE TABLE IF NOT EXISTS user (
                UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                RoleID INTEGER NOT NULL,
                FullName TEXT NOT NULL
                 );");

                createTableScripts.Add(@"
                CREATE TABLE IF NOT EXISTS item (
                ItemID INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Description TEXT NOT NULL
                );");

                createTableScripts.Add(@"
                CREATE TABLE IF NOT EXISTS Trip (
                TripId INTEGER PRIMARY KEY AUTOINCREMENT,
                StartLocation TEXT NOT NULL,
                EndLocation TEXT NOT NULL
                );");

                createTableScripts.Add(@"
                CREATE TABLE IF NOT EXISTS Role ( 
                RoleId INTEGER PRIMARY KEY AUTOINCREMENT,
                Role TEXT NOT NULL,
                FullName TEXT NOT NULL
                );");

                createTableScripts.Add(@"
                CREATE TABLE IF NOT EXISTS Vehicle (
                VehicleId INTEGER PRIMARY KEY AUTOINCREMENT,
                LicensePlate TEXT UNIQUE NOT NULL,
                Capacity INTEGER NOT NULL,
                DriverId INTEGER NOT NULL
                );");

                createTableScripts.Add(@"
                CREATE TABLE IF NOT EXISTS TripManifest (
                ManifestId INTEGER PRIMARY KEY AUTOINCREMENT,
                TripId INTEGER NOT NULL,
                PickUpRequest INTEGER NOT NULL
                );");

                createTableScripts.Add(@"
                CREATE TABLE IF NOT EXISTS Bill (
                BillId INTEGER PRIMARY KEY AUTOINCREMENT,
                Fullname TEXT NOT NULL,
                Email TEXT NOT NULL
                );");

                createTableScripts.Add(@"
                CREATE TABLE IF NOT EXISTS Expense (
                ExpenseId INTEGER PRIMARY KEY AUTOINCREMENT,
                DriverId INTEGER NOT NULL,
                VehicleId INTEGER NOT NULL
                );");

                createTableScripts.Add(@"
                CREATE TABLE IF NOT EXISTS Event (
                EventId INTEGER PRIMARY KEY AUTOINCREMENT,
                DriverId INTEGER NOT NULL
                );");

              //  createTableScripts.Add(@"
              //  CREATE TABLE IF NOT EXISTS Waypoint (
                 
              //  )");

                

                foreach (string tableScript in createTableScripts) 
                {
                    var command = new SQLite.SQLiteCommand(connection);
                    command.CommandText = tableScript;
                    command.ExecuteNonQuery();
                }
            }

        }
    }

}