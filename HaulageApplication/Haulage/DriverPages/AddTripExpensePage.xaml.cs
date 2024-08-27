using SQLite;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Haulage.DriverPages;

public partial class AddTripExpensePage : ContentPage
{
    public AddTripExpensePage()
    {
        InitializeComponent();
    }

    private void SaveExpenseRecord_Clicked(object sender, EventArgs e)
    {
        Button SaveExpenseRecord = FindByName("SaveExpenseRecord") as Button;
        SaveExpenseRecord.Clicked += SaveExpenseRecord_Clicked;

        string expenseId = ExpenseIdEntry.Text;
        string driverId = DriverIdEntry.Text;
        string vehicleId = VehicleIdEntry.Text;
        string fullname = FullnameEntry.Text;
        string expense = ExpenseEntry.Text;
        string expenseDescription = ExpenseDescEntry.Text;
        string expenseCost = ExpenseCostEntry.Text;

        var sql = $"INSERT INTO Expense VALUES ({expenseId}, {driverId}, {vehicleId}, '{fullname}', '{expense}', '{expenseDescription}', '{expenseCost}');";


        using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        DisplayAlert("Success", "Expense details saved successfully.", "OK");
        Console.WriteLine("Expense successfully Added");

    }

}






