using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass()]
    public class VendingMachineTests
    {


        [TestMethod]
        public void FeedMoney_AddAndUpdatesCurrentBalance_Test()
        {

            //public void FeedMoney(int amountOfMoney)
            //{
            //    this.CurrentBalance += amountOfMoney;
            //}

            // Arrange - set up the code we want to test; (1) initialize the object (2) create a test parameter (3) expected value
            VendingMachine vendoMatic = new VendingMachine();
            int param = 5;
            double expectedValue = vendoMatic.CurrentBalance + 5;

            // Act - call the method being tested
            vendoMatic.FeedMoney(param);

            // Assert - Verify that the system under test behaved the w
            Assert.AreEqual(expectedValue, vendoMatic.CurrentBalance);
        }






        //public void SpendMoney(double price)
        //{
        //    CurrentBalance -= price;
        //}

        [TestMethod]
        public void SpendMoney_SubtractFromCurrentBalance_Test()
        {
            VendingMachine vendoMatic = new VendingMachine();
            double param = 1.75;
            double expectedValue = -1.75;

            vendoMatic.SpendMoney(param);

            Assert.AreEqual(expectedValue, vendoMatic.CurrentBalance);

        }






        [TestMethod]
        public void SelectAndBuyItem_AddToTotalSpent_UpdateTotalSpent_Test()
        {
            // Arrange - setting up your test w/ instance of class, create test parameter, expected output
            VendingMachine vendoMatic = new VendingMachine();
            double param = 5.55;
            double expectedValue = vendoMatic.TotalSpent + 5.55;

            // Act
            vendoMatic.TrackSpending(param); /// call the method being tested

            // Assert
            Assert.AreEqual(expectedValue, vendoMatic.TotalSpent);
        }






        [TestMethod]
        public void StockTheMachine_ReadFromFileToAdd16ItemsToList_CheckItemCountIs16_Test()
        {
            // Arrange - **this test does not need parameters because the method being tested does have a parameter set
            VendingMachine vendoMatic = new VendingMachine();
            int expectedValue = 16;

            // Act - calling the method that is being tested.
            vendoMatic.StockTheMachine();

            // Assert - 
            Assert.AreEqual(expectedValue, vendoMatic.Stock.Count);
        }





        [TestMethod]
        public void ReturnChange_ConvertBalanceToCoins_Test()
        {
            // Arrange
            VendingMachine vendoMatic = new VendingMachine();
            int expectedQuarter = 2; // .50
            int expectedDime = 1; // .60
            int expectedNickel = 1; // .05
            double paramBalance = 0.65;

            // Act
            vendoMatic.ReturnChange(paramBalance);

            // Assert
            Assert.AreEqual(expectedQuarter, vendoMatic.Quarter, "Quarter conversion error");
            Assert.AreEqual(expectedDime, vendoMatic.Dime, "Dimes conversion error");
            Assert.AreEqual(expectedNickel, vendoMatic.Nickel, "Nickel conversion error");













        }
    }
}

