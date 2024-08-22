using System.Collections.ObjectModel;
using System;
using Haulage.BaseClasses.BillingHandler;
using SQLite;
using Haulage.DatabaseExecutionServices;
namespace Haulage.CustomerPages;

public partial class ManageCardDetailsPage : ContentPage
{
	public ManageCardDetailsPage()
	{
		InitializeComponent();
	}

    private void DeleteCard_Clicked(object sender, EventArgs e)
    {
        var sql = $"DELETE FROM CustomerCardDetails WHERE CustomerID = {EntryCustomerId.Text}";

        using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        if (EntryCustomerId.Text != null)
        {
            var customerId = EntryCustomerId.Text.Trim();

            if (Int32.TryParse(customerId, out var parsedID))
            {
                DisplayAlert("Success", "card details removed successfully.", "OK");
                Console.WriteLine("card successfully removed");
            }
            else
            {
                Console.WriteLine("Unable to parse value");
                DisplayAlert("Error", $"Failed to delete {EntryCustomerId}", "OK");
            }
        }
        else
        {
            DisplayAlert("Error", $"No Customer Id has been entered", "Ok");
        }
    }

    private void AddCard_Clicked(object sender, EventArgs e)
    {
        AddCard.Clicked += async (sender, args) => { await Navigation.PushAsync(new AddCardPage()); };
    }
}