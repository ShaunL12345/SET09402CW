namespace Haulage;
using Haulage.ViewModels;
public partial class ManageCustomerBillsPage : ContentPage
{
	public ManageCustomerBillsPage()
	{
		InitializeComponent();
	}


    public void OnEntryCompleted(object sender, EventArgs e)
    {
        AdminManageCustomerBillView context = (AdminManageCustomerBillView)this.BindingContext;

        if (Int32.TryParse(((Entry)sender).Text, out int custid))
        {
            context.CustomerId = custid;

        }
    }
}