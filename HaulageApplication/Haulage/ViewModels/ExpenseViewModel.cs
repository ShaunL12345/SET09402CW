using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses.Accounting;
using Haulage.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Haulage.BaseClasses.BillingHandler;
using Haulage.DatabaseExecutionServices;

namespace Haulage.viewModel
{
    public class ExpenseViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Expense>? Expenses { get; set; }
        public ExpenseViewModel()
        {
            Expenses = new ObservableCollection<Expense>();
            var ExpenseObjects = ExpenseModel.Expenses;
            foreach (var ExpenseObject in ExpenseObjects)
            {
                Expenses.Add(ExpenseObject);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}