namespace Haulage;

using Haulage.BaseClasses.Accounting;
using SQLite;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Haulage.DatabaseExecutionServices;
using System.Text;
using Haulage.BaseClasses;
public partial class AddEmployee : ContentPage
{
   
   
    public AddEmployee()
	{
		InitializeComponent();

        Button SaveEmployee = FindByName("SaveEmployee") as Button;
        SaveEmployee.Clicked += SaveEmployee_Clicked;

        
    }

    public void SaveEmployee_Clicked(object sender, EventArgs e)
    {

        string employeeUserId = UserIdEntry.Text;
        string employeeFullname = FullnameEntry.Text;
        string employeeEmail = emailEntry.Text;
        string employeeNumber = phoneNumberEntry.Text;
        string employeeRole = roleEntry.Text;
        Role employeeRoleEnum = Enum.Parse<Role>(roleEntry.Text.ToLower());
        string employeeAddress = addressEntry.Text;
        string employeeQualification = qualificationEntry.Text;

        Driver driver = new Driver(Int32.Parse(employeeUserId), employeeFullname, employeeEmail, employeeNumber, employeeRoleEnum, employeeAddress, employeeQualification);
        DriverExecutionService.SaveDriver(driver);
    }


}