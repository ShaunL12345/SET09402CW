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
                DropTables(connection);
                CreateTables(connection);
                GenerateData(connection);
            }
        }
    }

    public static void DropTables(SQLiteConnection connection) 
    {
        List<string> dropTableScripts = new List<string>();

        dropTableScripts.Add("DROP TABLE IF EXISTS [User]");
        dropTableScripts.Add("DROP TABLE IF EXISTS [Bill]");
        dropTableScripts.Add("DROP TABLE IF EXISTS [Event]");
        dropTableScripts.Add("DROP TABLE IF EXISTS [Expense]");
        dropTableScripts.Add("DROP TABLE IF EXISTS [Item]");
        dropTableScripts.Add("DROP TABLE IF EXISTS [Role]");
        dropTableScripts.Add("DROP TABLE IF EXISTS [Trip]");
        dropTableScripts.Add("DROP TABLE IF EXISTS [TripManifest]");
        dropTableScripts.Add("DROP TABLE IF EXISTS [Vehicle]");

        foreach (string table in dropTableScripts)
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = table;
            command.ExecuteNonQuery();
        }
    }

    private static void GenerateData(SQLiteConnection connection)
    {
        //Vehicle data
        CreateVehicles(connection);




    }

    private static void CreateVehicles(SQLiteConnection connection)
    {
        List<string> dataScripts = new List<string>();

        dataScripts.Add(@"
        INSERT INTO[Vehicle]
           ([VehicleId]
           , [LicensePlate]
           , [Capacity]
           , [DriverId]
           , [Status])
             VALUES
            (1, 'test1', 1, 1,1);");
        
        dataScripts.Add(@"
        INSERT INTO[Vehicle]
           ([VehicleId]
           , [LicensePlate]
           , [Capacity]
           , [DriverId]
           , [Status])
             VALUES
           (2, 'test2', 2, 2,1);");
        
        dataScripts.Add(@"
        INSERT INTO[Vehicle]
           ([VehicleId]
           , [LicensePlate]
           , [Capacity]
           , [DriverId]
           , [Status])
             VALUES
           (3, 'test3', 3, 3,3);");

        foreach (string tableScript in dataScripts)
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = tableScript;
            command.ExecuteNonQuery();
        }
    }

    private static void CreateTables(SQLiteConnection connection)
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
                DriverId INTEGER NOT NULL,
                Status INTEGER NOT NULL
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