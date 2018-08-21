using BankingApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppTests
{
    [TestClass()]
    public class CreditCardTests
    {
        [TestMethod()] // Test #1
        public void Deposit_PositiveAmount_ShouldAddToExistingBalance()
        {
            // ARRANGE - 
            double startBalance = 555;
            CreditCard CC = new CreditCard(startBalance);
            
            double depositAmount = 10.5;
            double expectedBalance = startBalance -
                                            depositAmount;

            // ACT - Run method under test
            CC.Deposit(depositAmount);

            // ASSERT - Check if test passes or fails
            Assert.AreEqual(expectedBalance, CC.CCBalance);
        }

        [TestMethod()] // Test #2
        public void Withdraw_From_Bank_Results()
        {
            double startBalance = 500;
            BankAccount bank = new BankAccount(startBalance);
            
            double withdraw = 250.0;
            double result = startBalance - withdraw;

            bank.Withdraw(withdraw);

            Assert.AreEqual(result, bank.Balance);
        }

        [TestMethod()] // Test #3
        public void Pay_CC_From_Bank()
        {
            double startBalance = 500;
            BankAccount bank = new BankAccount(startBalance);
     
            double withdraw = 250.0;
            double result = startBalance - withdraw;


            double startOwed = 4234.91;
            CreditCard cc = new CreditCard(startOwed);
            
            double amtPaid = withdraw;
            double ccBalance = startOwed - amtPaid;

            bank.Withdraw(withdraw);
            cc.Deposit(withdraw);

            Assert.AreEqual(result, bank.Balance);
            Assert.AreEqual(cc.CCBalance , ccBalance);
        }


        [TestMethod()] // Test #4
        public void Put_Money_From_CC_To_Bank()
        {
            double startBalance = 500;
            BankAccount bank = new BankAccount(startBalance);

            double deposit = 250.0;
            double result = startBalance + deposit;
            

            double startOwed = 4234.91;
            CreditCard cc = new CreditCard(startOwed);

            double amtSpent = deposit;
            double ccBalance = startOwed + amtSpent;

            bank.Deposit(deposit);
            cc.Withdraw(deposit);

            Assert.AreEqual(result, bank.Balance);
            Assert.AreEqual(cc.CCBalance, ccBalance);
        }

        [TestMethod()] // Test #5
        public void Put_Money_From_CC_CashAdvance_W_Interest_To_Bank()
        {
            double startBalance = 500;
            BankAccount bank = new BankAccount(startBalance);

            double deposit = 250.0;
            double result = startBalance + deposit;


            double startOwed = 4234.91;
            CreditCard cc = new CreditCard(startOwed);
            double ccInterest = .1999;
            double amtSpent = deposit;
            double ccBalance = startOwed + amtSpent + (ccInterest * amtSpent);

            bank.Deposit(deposit);
            cc.CashAdvance(deposit, ccInterest);

            Assert.AreEqual(result, bank.Balance);
            Assert.AreEqual(cc.CCBalance, ccBalance);
        }
    }
}
