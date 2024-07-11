using SQLite;
using System.Data.SqlTypes;
using System.IO;
using System.Security.Cryptography.X509Certificates;


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

    public static string connectionString = $"Data Source={GetDatabasePath()};Version=3;";


    public static void InitializeDatabase()
    {
        if (File.Exists($@"{GetDatabasePath()}"))
        {

            using (var connection = new SQLiteConnection(GetDatabasePath()))
            {


                //Create User Table for Haulage Data;

                string createUsersTableQuery = @"
                CREATE TABLE IF NOT EXISTS users (
                UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                RoleID INTEGER NOT NULL,
                FullName TEXT NOT NULL
                 );"
                ;


                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = createUsersTableQuery;
                command.ExecuteNonQuery();

            }
        }
    }

}