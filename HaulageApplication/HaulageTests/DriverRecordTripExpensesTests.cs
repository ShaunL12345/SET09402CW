using Haulage.BaseClasses.BillingHandler;
using Haulage.DatabaseExecutionServices;
using Haulage.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage;

namespace HaulageTests
{
    [CollectionDefinition("DatabaseTests", DisableParallelization = true)]
    public class DriverRecordTripExpensesTests
    {
        [Fact]
        public void GetExpenseViewModel()
        {
            //Arrange
            DatabaseSetup.InitializeDatabase();

            //Act
            var model = new ExpenseViewModel();

            //Assert
            Assert.NotNull(model);
            Assert.True(model.Expenses.Count > 0);
        }

        [Fact]

        public void GetExpensesFromDatabase()
        {
            //Arrange
            DatabaseSetup.InitializeDatabase();

            //Act
            var expenses = ExpenseExecutionService.GetExpenses();
            Assert.NotNull(expenses);
            Assert.True(expenses.Count > 0, "Did not recieve any records from GetExpenses method");
        }

        [Fact]
        public void DeleteExpenseFromDatabse()
        {
            //Arrange
            DatabaseSetup.InitializeDatabase();
          
            var expenses = ExpenseExecutionService.GetExpenses();

            //Act
            var expenseToRemove = expenses.First();
            var initialExpenseCount = expenses.Count;
            ExpenseExecutionService.DeleteExpense(expenseToRemove.expenseId);
            var expenseCountAfter = ExpenseExecutionService.GetExpenses().Count;

            //Assert
            Assert.True(expenseCountAfter == initialExpenseCount - 1, "Failed to delete an expense record");
        }

        [Fact]

        public void SaveExpenseInDatabase()
        {
            //Arrange
            DatabaseSetup.InitializeDatabase();

            //Act
            var expenses = ExpenseExecutionService.GetExpenses();
            var aNewExpense = new Expense(1234, 123456, 928393, "Aidan Gallagher", "Food Allowance", "Food allowance from company", "£20.00");
            var initialExpenseCount = expenses.Count;
            ExpenseExecutionService.SaveExpense(aNewExpense);
            var ExpenseCountAfter = ExpenseExecutionService.GetExpenses().Count;

            //Assert
            Assert.True(ExpenseCountAfter == initialExpenseCount + 1, "Saved expense record successfully");

        }


    }
}
