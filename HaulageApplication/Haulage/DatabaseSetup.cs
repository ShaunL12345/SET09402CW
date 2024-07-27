using SQLite;
using System.Data.SqlTypes;
using System.IO;
using System.Security.Cryptography.X509Certificates;


public static class DatabaseSetup
{
    /// <summary>
    /// This method is currently assuming that the project where it is being called from has its own db.
    /// This should be changed in the future to add a flag which indicts which db to use
    /// </summary>
    /// <returns></returns>
    public static string GetDatabasePath()
    {
        // Get the base directory of the application
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        //Gets the relative path to a database where it is being called from. 
        
        string[] parts = baseDirectory.Split("HaulageApplication");
        var project = parts[1].Split(Path.DirectorySeparatorChar)[1];
        var relativePath = Path.Combine(parts[0], "HaulageApplication" ,project, "Database\\Haulage.db");

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

    //Drops all the tables inside the database 
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
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = table;
            command.ExecuteNonQuery();
        }
    }

    public static void GenerateData(SQLiteConnection connection)
    {
        //Vehicle data
        CreateVehicles(connection);
    }

    private static void CreateVehicles(SQLiteConnection connection)
    {
        List<string> dataScripts = new List<string>
        {
            @"INSERT INTO [Vehicle] ([VehicleId], [tripID], [LicensePlate], [Capacity], [DriverId], [Status]) VALUES (1, 1, 'test1', 1, 1, 1);",
            @"INSERT INTO [Vehicle] ([VehicleId], [tripID], [LicensePlate], [Capacity], [DriverId], [Status]) VALUES (2, 2, 'test2', 2, 2, 2);",
            @"INSERT INTO [Vehicle] ([VehicleId], [tripID], [LicensePlate], [Capacity], [DriverId], [Status]) VALUES (3, 3, 'test3', 3, 3, 3);"
        };
        foreach (string tableScript in dataScripts)
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = tableScript;
            command.ExecuteNonQuery();
        }
    }

    public static void CreateTables(SQLiteConnection connection)
    {

        List<string> createTableScripts = new List<string>
        {
            @"CREATE TABLE IF NOT EXISTS User (UserID INTEGER PRIMARY KEY AUTOINCREMENT, RoleID INTEGER NOT NULL, FullName TEXT NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS Item (ItemID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Description TEXT NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS Trip (TripId INTEGER PRIMARY KEY AUTOINCREMENT, StartLocation TEXT NOT NULL, EndLocation TEXT NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS Role (RoleId INTEGER PRIMARY KEY AUTOINCREMENT, RoleDesc TEXT NOT NULL, FullName TEXT NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS Vehicle (VehicleId INTEGER PRIMARY KEY AUTOINCREMENT, TripID INTEGER, LicensePlate TEXT UNIQUE NOT NULL, Capacity INTEGER NOT NULL, DriverId INTEGER NOT NULL, Status INTEGER NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS TripManifest (ManifestId INTEGER PRIMARY KEY AUTOINCREMENT, TripId INTEGER NOT NULL, PickUpRequest INTEGER NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS Bill (BillId INTEGER PRIMARY KEY AUTOINCREMENT, Fullname TEXT NOT NULL, Email TEXT NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS Expense (ExpenseId INTEGER PRIMARY KEY AUTOINCREMENT, DriverId INTEGER NOT NULL, VehicleId INTEGER NOT NULL);",
            @"CREATE TABLE IF NOT EXISTS Event (EventId INTEGER PRIMARY KEY AUTOINCREMENT, DriverId INTEGER NOT NULL);"
        };

        foreach (string tableScript in createTableScripts)
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = tableScript;
            command.ExecuteNonQuery();
        }

    }

}
