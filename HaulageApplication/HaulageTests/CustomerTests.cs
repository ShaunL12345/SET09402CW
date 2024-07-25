using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SQLite;
using Haulage.DatabaseExecutionServices;
using Haulage.BaseClasses.BillingHandler;
using NuGet.Frameworks;

namespace HaulageTests
{
    public class CustomerTests
    {
        private SQLiteConnection GetInMemoryConnection()
        {
            var connection = new SQLiteConnection(":memory:");
            return connection;
        }

        [Fact]
        //Unit test to get Bills from Database table
        public void GetBillFromDatabase()
        {
            //Arrange
            var connection = GetInMemoryConnection();
            DatabaseSetup.InitializeDatabase();
            DatabaseSetup.CreateTables(connection);
            DatabaseSetup.GenerateData(connection);

            //Act
            var bills = BillExecutionService.GetBills();


            //Assert
            Assert.NotNull(bills);
            Assert.True(bills.Count > 0, "Did not recieve any records from BetBills methos");
        }

        [Fact]
        //Unit test to delete Bills from Database table
        public void DeleteBillFromDatabase()
        {
            //Arrange
            var connection = GetInMemoryConnection();
            DatabaseSetup.InitializeDatabase();
            DatabaseSetup.GenerateData(connection);
            DatabaseSetup.CreateTables(connection);

            //Act
            var bills = BillExecutionService.GetBills(connection);
            var billsToRemove = bills.First();
            var initialBillCount = bills.Count;
            BillExecutionService.DeleteBill(billsToRemove.BillId, connection);
            var billCountAfter = BillExecutionService.GetBills(connection).Count;

            //Assert
            Assert.True(billCountAfter == initialBillCount - 1, "Failed to delete a bill");
        }


    }
}
