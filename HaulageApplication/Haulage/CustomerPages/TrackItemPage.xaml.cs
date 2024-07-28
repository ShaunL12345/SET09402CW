using Haulage.ViewModels;

namespace Haulage.CustomerPages;

public partial class TrackItemPage : ContentPage
{
	public TrackItemPage()
	{
		InitializeComponent();
	}

	public void OnEntryCompleted(object sender, EventArgs e)
    {
		CustomerItemView context = (CustomerItemView)this.BindingContext;
		
	    if(Int32.TryParse(((Entry)sender).Text, out int custid)) {
			context.CustomerId = custid;

        }
    }
}