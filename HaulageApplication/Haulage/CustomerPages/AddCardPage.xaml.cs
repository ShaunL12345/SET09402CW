namespace Haulage;

using System.Collections.ObjectModel;
using System;
using Haulage.BaseClasses.BillingHandler;
using SQLite;
using Haulage.DatabaseExecutionServices;


public partial class AddCardPage : ContentPage
{
	public AddCardPage()
	{
        InitializeComponent();
	}

    private void SaveCard_Clicked(object sender, EventArgs e)
    {
        string customerId = CustomerIdEntry.Text;
        string customerCardNumber = CardNumberEntry.Text;
        string customerCardExpiryDate = ExpiryDateEntry.Text;
        string customerSecurityCode = SecurityCodeEntry.Text;
        string customerNameOnCard = NameOnCardEntry.Text;

        var sql = $"INSERT INTO CustomerCardDetails VALUES ({customerId}, '{customerCardNumber}', '{customerCardExpiryDate}', {customerSecurityCode}, '{customerNameOnCard}');";

        using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = sql;
            command.ExecuteQuery<DBNull>();
        }

        DisplayAlert("Success", "Card details saved successfully.", "OK");
        Console.WriteLine("Card successfully Added");
    }
}