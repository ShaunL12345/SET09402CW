using Haulage.BaseClasses.Accounting;
using Haulage.viewModel;
using SQLite;
using System.Runtime.CompilerServices;


namespace Haulage;

public partial class ManageEmployees : ContentPage
{
	public ManageEmployees()
	{
        InitializeComponent();

        Button AddEmployee = FindByName("AddEmployee") as Button;
        AddEmployee.Clicked += async (sender, args) => { await Navigation.PushAsync(new AddEmployee()); };

    }

    private void AddEmployee_Clicked(object sender, EventArgs e)
    {

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

        //DriversCollectionView.ItemsSource = null;
        //DriversCollectionView.ItemsSource = "{Binding drivers}";
    }

    private void Collection_Loaded(object sender, EventArgs e)
    {
        OnPropertyChanged(nameof(DriversCollectionView));
    }




}