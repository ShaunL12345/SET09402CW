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

    private void UpdateEmployee_Clicked(object sender, EventArgs e)
    {

    }

    private void DeleteEmployee_Clicked(object sender, EventArgs e)
    {

    }
}