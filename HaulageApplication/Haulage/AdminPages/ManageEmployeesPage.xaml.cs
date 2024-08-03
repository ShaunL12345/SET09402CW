using Haulage.BaseClasses.Accounting;
using Haulage.DatabaseExecutionServices;
using Haulage.viewModels;
using SQLite;
using System.Runtime.CompilerServices;



namespace Haulage;

public partial class ManageEmployeesPage : ContentPage
{
	public ManageEmployeesPage()
	{
        InitializeComponent();
    }

    private void DeleteEmployee_Clicked(object sender, EventArgs e)
    {

        var sql = $"DELETE FROM User WHERE UserId = {entryUserId.Text}";

        using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        if (entryUserId.Text != null)
        {
            var userId = entryUserId.Text.Trim();

            if (Int32.TryParse(userId, out var parsedID))
            {
                DriverExecutionService.DeleteDriver(parsedID);
                Console.WriteLine("Employee Removed Successfully");
                DisplayAlert("Success", $"{userId} removed successfully.", "OK");
            }
            else
            {
                Console.WriteLine("Unable to parse value");
                DisplayAlert("Error", $"Failed to delete {userId}", "OK");
            }
        }


    }

    private async void AddEmployee_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddEmployee());
    }

    private void Collection_Loaded(object sender, EventArgs e)
    {
        OnPropertyChanged(nameof(DriversCollectionView));
    }

}