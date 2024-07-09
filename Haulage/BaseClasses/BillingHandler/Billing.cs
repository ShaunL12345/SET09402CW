using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.BillingHandler
{
    public class Billing
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Guid customerID;
        public float totalAmount;
        enum Billingstatus
        {
            notPaid,
            paid

        }
        public Billing() { }

        public void updateBillingStatus()
        {

        }
    }
}
