using Haulage.DatabaseExecutionServices;

namespace Haulage.AdminPages;

public partial class ManageCustomerPage : ContentPage
{
	public ManageCustomerPage()
	{
		InitializeComponent();
    }



    public void DeleteCustomer_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(EntryCustomerId.Text))
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
        else 
        {
            DisplayAlert("Error", $"No user id has been entered", "OK");
        }
    }

    private async void AddEmployee_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddEmployee());
    }
}