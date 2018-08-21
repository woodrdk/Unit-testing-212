using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        [TestMethod()]
        public void Deposit_PositiveAmount_ShouldAddToExistingBalance()
        {
            // ARRANGE - Create variables and objects
            // for test
            BankAccount bank = new BankAccount();
            double startBalance = 0;
            double depositAmount = 10.5;
            double expectedBalance = startBalance +
                                            depositAmount;

            // ACT - Run method under test
            bank.Deposit(depositAmount);

            // ASSERT - Check if test passes or fails
            Assert.AreEqual(expectedBalance, bank.Balance);
        }

        [TestMethod]
        public void Deposit_PositiveAmount_ReturnsNewBalance()
        {
            //Arrange
            BankAccount acc = new BankAccount();
            double depositAmt = 5.5;
            double expectedReturn = 5.5;

            //Act
            double actualReturn =
                    acc.Deposit(depositAmt);

            //Assert
            Assert.AreEqual(expectedReturn,
                                    actualReturn);
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        [DataRow(-.01)]
        [DataRow(-1000)]
        [DataRow(-.0000001)]
        [DataRow(double.MinValue)]


        public void Deposit_NegativeAmount_ShouldThrowException(double invalidDeposit)
        {
            //Arrange
            BankAccount bank = new BankAccount();
            //double invalidDeposit = -0.01;

            //Act
            //Assert handled by [ExpectedException]
            //bank.Deposit(invalidDeposit);

            //Act => Assert
            Assert.ThrowsException<ArgumentException>
                (() => bank.Deposit(invalidDeposit));
        }

        [TestMethod]
        public void Withdraw_PositiveAmount_ShouldSubtractFromBalance()
        {
            // Arrange
            BankAccount account = GetAccount();
            double initialBalance = 100;
            double withdrawAmount = 50;
            double expectedAmount = 50;
            account.Deposit(initialBalance);

            // Act
            double result = account.Withdraw(withdrawAmount);

            // Assert
            Assert.AreEqual(expectedAmount, account.Balance);
            Assert.AreEqual(expectedAmount, result);
        }

        private BankAccount GetAccount()
        {
            BankAccount acc = new BankAccount();
            return acc;
        }

        [TestMethod()]
        public void Creat_AccountWithBalance_ShouldHaveBalanceTest()
        {
            double acc2Amt = 500;
            double acc3Amt = 100;
            BankAccount acc = new BankAccount();
            BankAccount acc2 = new BankAccount(500);
            BankAccount acc3 = new BankAccount(100, "123");
            Assert.AreEqual(0, acc.Balance);
            Assert.AreEqual(acc2Amt, acc2.Balance);
            Assert.AreEqual(acc3Amt, acc3.Balance);
        }
        
    }

    [TestClass()]
    public class CreditCardTests
    {
        [TestMethod()]
        public void Deposit_PositiveAmount_ShouldAddToExistingBalance()
        {
            // ARRANGE - Create variables and objects
            // for test
            CreditCard CC = new CreditCard();
            double startBalance = 0;
            double depositAmount = 10.5;
            double expectedBalance = startBalance +
                                            depositAmount;

            // ACT - Run method under test
            CC.Deposit(depositAmount);

            // ASSERT - Check if test passes or fails
            Assert.AreEqual(expectedBalance, CC.CCBalance);
        }
    }
}