using System.Collections.ObjectModel;
using System;
using Haulage.BaseClasses.BillingHandler;
using SQLite;
namespace Haulage.CustomerPages;
public partial class ManageBillingPage : ContentPage
{
	public ManageBillingPage()
	{
		InitializeComponent();

        Button AddBills = FindByName("AddBills") as Button;
        AddBills.Clicked += async (sender, args) => { await Navigation.PushAsync(new AddBillPage()); };
    }

    private void AddBills_Clicked(object sender, EventArgs e)
    {

    }

    private void DeleteBill_Clicked(object sender, EventArgs e)
    {
        var sql = $"DELETE FROM Bill WHERE BillID = {BillId}";

        using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

    }
}