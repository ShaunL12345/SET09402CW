using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    public class Customer : Person
    {
        public Customer() { }

// = MANAGE ACCOUNT = START ========================================================================================================= //

        public void ManageAccount(Account account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));

            // Assume some logic here to save account details
            Console.WriteLine("Account details managed successfully.");
        }

        public void RequestPickupOrDelivery() { }
        public void ConfirmPickupOrDelivery() { }
        public void TrackItem() { }
        public void ManageBilling() { }

// = MANAGE ACCOUNT = END =========================================================================================================== //

        public void requestPickupOrDelivery()
        {

        }

        public void confirmPickupOrDelivery()
        {

        }

        public void trackItem()
        {

        }

        public void manageBilling()
        {

        }

    }

// = ACCOUNT = START ================================================================================================================ //
    public class Account
    {
        public string BillingDetails { get; set; }
        public string ContactDetails { get; set; }
    }

// = ACCOUNT = END ================================================================================================================== //

}
