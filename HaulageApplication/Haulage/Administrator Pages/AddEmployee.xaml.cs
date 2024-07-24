namespace Haulage;
using SQLite;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public partial class AddEmployee : ContentPage
{
   
   
    public AddEmployee()
	{
		InitializeComponent();

        Button SaveEmployee = FindByName("SaveEmployee") as Button;
        SaveEmployee.Clicked += SaveEmployee_Clicked;

       
    }

    public void SaveEmployee_Clicked(object sender, EventArgs e)
    {

        string employeeID = idEntry.Text;
        string employeeName = nameEntry.Text;
        string employeeEmail = emailEntry.Text;
        string employeeNumber = phoneNumberEntry.Text;
        string employeeRole = roleEntry.Text;
        string employeeAddress = addressEntry.Text;
        string employeeQualification = qualificationEntry.Text;

        var sql = $"INSERT INTO USER VALUES ({employeeID}, '{employeeName}', '{employeeEmail}', '{employeeNumber}', '{employeeRole}', '{employeeAddress}', '{employeeQualification}');";
            
        
        using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = sql;
            command.ExecuteQuery<DBNull>();
        }

    }
}