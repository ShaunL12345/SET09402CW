using Haulage.DatabaseExecutionServices;

namespace Haulage.AdminPages;

public partial class ManageCustomerPage : ContentPage
{
	public ManageCustomerPage()
	{
		InitializeComponent();
        AddEmployee.Clicked += async (sender, args) => { await Navigation.PushAsync(new AddEmployee()); };
    }



    public void DeleteCustomer_Clicked(object sender, EventArgs e)
    {
        if (EntryCustomerId.Text != null)
        {
            var userId = EntryCustomerId.Text.Trim();

            if (Int32.TryParse(userId, out var parsedID))
            {
                CustomerExecutionService.deleteCustomer(parsedID);
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
}