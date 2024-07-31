using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.BillingHandler
{
    public class Expense
    {
        public int expenseId { get; set; }
        public int driverId { get; set; }
        public int vehicleId { get; set; }
        public string fullname { get; set; }
        public string expense { get; set; }
        public string expenseDescription { get; set; }
        public string expenseCost { get; set; }

        public Expense() { }

        public Expense(int driverExpenseId, int driverId, int vehicleId, string driverFullname, string driverExpense, string driverExpenseDesc, string driverExpenseCost)
        {
            this.expenseId = driverExpenseId;
            this.driverId = driverId;
            this.vehicleId = vehicleId;
            this.fullname = driverFullname;
            this.expense = driverExpense;
            this.expenseDescription = driverExpenseDesc;
            this.expenseCost = driverExpenseCost;
        }




    }
}

