using Haulage.BaseClasses.Accounting;
using Haulage.Services;

namespace Haulage;

public partial class CustomerPage : ContentPage
{
    CustomerServiceDatabase database;

    public CustomerPage(CustomerServiceDatabase CustomerDatabase)
    {
        //this.BindingContext = new Customer();
        database = CustomerDatabase;
    }
}

