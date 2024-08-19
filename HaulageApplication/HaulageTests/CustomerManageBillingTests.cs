using System;
using System.IO;
using Xunit;
using SQLite;
using Haulage.DatabaseExecutionServices;
using Haulage.Models;
using Haulage.BaseClasses.Accounting;
using Haulage.viewModels;
using Haulage.AdminPages;
using Haulage.BaseClasses.BillingHandler;
using Haulage.BillviewModel;
using Haulage;

namespace HaulageTests;

[CollectionDefinition("DatabaseTests", DisableParallelization = true)]
public class CustomerManageBillingTests
{
    [Fact]
    public void GetBillViewModel()
    {
        //Arrange
        DatabaseSetup.InitializeDatabase();

        //Act
        var model = new BillViewModel();

        //Assert
        Assert.NotNull(model);
        Assert.True(model.Bills.Count > 0);
    }

    [Fact]
    public void GetBillsFromDatabase()
    {
        //Arrange
        DatabaseSetup.InitializeDatabase();

        //Act
        var bills = BillExecutionService.GetBills();

        //Assert
        Assert.NotNull(bills);
        Assert.True(bills.Count > 0, "Did not recieve any records from GetBills method");
    }

    [Fact]

    public void DeleteBillsFromDatabase()
    {
        //Arrange
        DatabaseSetup.InitializeDatabase();
        System.Threading.Thread.Sleep(800);

        //Act
        var bills = BillExecutionService.GetBills();
        var billsToRemove = bills.First();
        var initialBillCount = bills.Count;
        BillExecutionService.DeleteBill(billsToRemove.BillId);
        System.Threading.Thread.Sleep(150);
        var BillCountAfter = BillExecutionService.GetBills().Count;
        System.Threading.Thread.Sleep(150);

        //Assert
        Assert.True(BillCountAfter == initialBillCount - 1, "Failed to delete a bill record");
    }

    [Fact]

    public void SaveBillInDatabase()
    {
        //Arrange
        DatabaseSetup.InitializeDatabase();

        //Act
        var bills = BillExecutionService.GetBills();
        var aNewBill = new Billing(123456, "Aidan Gallagher", "aidan.gallagher@gmail.com", "Brake Pads", "Brake pads for test vehicle", 80.00);
        var initialBillCount = bills.Count;
        BillExecutionService.SaveBill(aNewBill);
        var BillCountAfter = BillExecutionService.GetBills().Count;

        //Assert
        Assert.True(BillCountAfter == initialBillCount + 1, "Saved bill record successfully");

    }

    [Fact]
    public void GetCardDetailsFromDatabase()
    {
        //Arrange
        DatabaseSetup.InitializeDatabase();
        System.Threading.Thread.Sleep(150);
        //Act
        var cards = BillExecutionService.GetCardDetails();

        //Assert
        Assert.NotNull(cards);
        Assert.True(cards.Count > 0, "Did not recieve any records from GetCards method");
    }

    [Fact]

    public void DeleteCardsFromDatabase()
    {
        //Arrange
        DatabaseSetup.InitializeDatabase();

        //Act
        var cards = BillExecutionService.GetCardDetails();
        var cardsToRemove = cards.First();
        var initialCardCount = cards.Count;
        BillExecutionService.DeleteCard(cardsToRemove.CustomerId);
        var CardCountAfter = BillExecutionService.GetCardDetails().Count;
        System.Threading.Thread.Sleep(150);

        //Assert
        Assert.True(CardCountAfter == initialCardCount - 1, "Failed to delete card");
    }

    [Fact]
    public void SaveCardInDatabase()
    {
        //Arrange
        DatabaseSetup.InitializeDatabase();

        //Act
        var cards = BillExecutionService.GetCardDetails();
        var aNewCard = new Billing(828377, "98548538", "10/27", 358, "Peter Hill");
        var initialCardCount = cards.Count();
        BillExecutionService.SaveCard(aNewCard);
        var CardCountAfter = BillExecutionService.GetCardDetails().Count();

        //Assert
        Assert.True(CardCountAfter == initialCardCount + 1, "Saved card successfully");

    }
}
