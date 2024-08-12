using Haulage.BaseClasses.Accounting;
using Haulage.DatabaseExecutionServices;
using Haulage.Models;
using Haulage.viewModel;
using SQLite;
using System.Runtime.CompilerServices;


namespace Haulage.DriverPages;

public partial class ManageExpensesPage : ContentPage
{
	public ManageExpensesPage()
	{
		InitializeComponent();

    }

    private void DeleteExpense_Clicked(object sender, EventArgs e)
    {

        var sql = $"DELETE FROM Expense WHERE ExpenseId = {entryExpenseId.Text}";

        using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        if (entryExpenseId.Text != null)
        {
            var expenseId = entryExpenseId.Text.Trim();

            if (Int32.TryParse(expenseId, out var parsedID))
            {
                ExpenseExecutionService.DeleteExpense(parsedID);
                Console.WriteLine("Expense Record Removed Successfully");
                DisplayAlert("Success", $"{expenseId} removed successfully.", "OK");
            }
            else
            {
                Console.WriteLine("Unable to parse value");
                DisplayAlert("Error", $"Failed to delete {expenseId}", "OK");
            }
        }
        else
        {
            DisplayAlert("Error", $"No Expense Id has been entered", "Ok");
        }

    }

    private void Collection_Loaded(object sender, EventArgs e)
    {
        OnPropertyChanged(nameof(ExpensesCollectionView));
    }

    private void AddExpenses_Clicked(object sender, EventArgs e)
    {
        AddExpenses.Clicked += async (sender, args) => { await Navigation.PushAsync(new AddTripExpensePage()); };
    }
}