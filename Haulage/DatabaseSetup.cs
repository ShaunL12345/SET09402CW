using SQLite;
using System.IO;

public static class DatabaseSetup
{
    private static string GetDatabasePath()
    {
        // Get the base directory of the application
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Combine the base directory with the relative path to the database
        string relativePath = Path.Combine(baseDirectory, @"..\..\..\..\..\Database\Haulage.db");

        // Resolve to a full absolute path
        return Path.GetFullPath(relativePath);
    }

    private static string connectionString = $"Data Source={GetDatabasePath()};Version=3;";


    public static void InitializeDatabase()
    {
        if (!File.Exists($@"{GetDatabasePath()}"))
        {
            //SQLiteConnection.CreateFile($@"{GetDatabasePath()}");

            //using (var connection = new SQLiteConnection(connectionString))
            //{
            //    connection.Open();

            //    // Create User Table for Haulage Data
            //    string createUsersTableQuery = @"
            //        CREATE TABLE IF NOT EXISTS users (
            //        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
            //        RoleID INTEGER NOT NULL,
            //        FullName TEXT NOT NULL
            //        );";

            //    //// Create <NAME> Table for Haulage Data
            //    //string createUsersTableQuery = @"
            //    //    CREATE TABLE IF NOT EXISTS users (
            //    //    id INTEGER PRIMARY KEY AUTOINCREMENT,
            //    //    etc.
            //    //    );";

            //    //using (var command = new SQLiteCommand(connection))
            //    //{
            //    //    command.CommandText = createUsersTableQuery;
            //    //    command.ExecuteNonQuery();
            //    //}

            //    // Execute Creat Table Commands
            //    using (var command = new SQLiteCommand(connection))
            //    {
            //        command.CommandText = createUsersTableQuery;
            //        command.ExecuteNonQuery();
            //    }
            //}
        }
    }

}