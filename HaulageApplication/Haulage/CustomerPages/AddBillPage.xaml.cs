using Haulage.BaseClasses.BillingHandler;
using Haulage.DatabaseExecutionServices;
using SQLite;
using System.Runtime.CompilerServices;
namespace Haulage;

public partial class AddBillPage : ContentPage
{
	public AddBillPage()
	{
		InitializeComponent();

		Button SaveBill = FindByName("SaveBill") as Button;
		SaveBill.Clicked += SaveBill_Clicked;
	}

    private void SaveBill_Clicked(object sender, EventArgs e)
    {
		string billId = BillIdEntry.Text;
		string Fullname = FullnameEntry.Text;
		string Email = EmailEntry.Text;

		var sql = $"INSERT INTO Bill VALUES ({billId}, '{Fullname}', '{Email}');";

        using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = sql;
            command.ExecuteQuery<DBNull>();
        }

		Console.WriteLine("Bill saved successfully!");

    }
}