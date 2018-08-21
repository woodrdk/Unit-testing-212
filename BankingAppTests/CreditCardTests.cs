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
            Assert.AreEqual(cc.CCBalance, ccBalance);
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


        [TestMethod()] // Test #6
        public void Pay_CC_Balance_W_Interest()
        {
            double ccBalance = 4234.91;
            CreditCard cc = new CreditCard(ccBalance);
            double ccInterest = .1999;
            double amountPaid = 345;
            double result = ((ccBalance * ccInterest) + ccBalance) - amountPaid;

            cc.InterestDeposit(amountPaid, ccInterest);
            Assert.AreEqual(result, cc.CCBalance);

        }

        [TestMethod()] // Test #7
        public void Pay_CC_Balance_W_Interest_And_OneTime_Payment()
        {
            double ccBalance = 4234.91;
            CreditCard cc = new CreditCard(ccBalance);
            double minDue = 256.34;
            double amountPaid = 345;
            double overpay = amountPaid - minDue;

            cc.InterestDepositWOneTime(amountPaid, minDue);
            Assert.AreEqual(overpay, cc.CCOverpay);
        }

        [TestMethod()] // Test #8 is it paid off
        public void PaidOff()
        {
            double ccBalance = 4234.91;
            CreditCard cc = new CreditCard(ccBalance);
            double amountPaid = 4234.91;
            double balance = ccBalance - amountPaid;
            string done = "YOU OWE NOTHING";
            cc.PaidOff(amountPaid);
            Assert.AreEqual(balance, cc.CCBalance);
        }

        [TestMethod()] // Test #9 was the cc  overpaid
        public void OverPaid()
        {
            double ccBalance = 4234.91;
            CreditCard cc = new CreditCard(ccBalance);
            double amountPaid = 4500;
            double balance = ccBalance - amountPaid;

            cc.OverPaid(amountPaid);
            Assert.AreEqual(balance, cc.CCBalance);
        }

        [TestMethod()] // Test #10 checking if the name is 
        // not sure if did this right was trying to sample with strings and bool

        public void CCHolder_Name()
        {
            CreditCard cc = new CreditCard();
            string CCAccountHolder = "User";

            cc.CCHolder_Name(CCAccountHolder);

            Assert.AreEqual(CCAccountHolder, cc.CCAccountHolder);
        }

        [TestMethod()] // Test #11 underpaid monthly payment
        public void UnderPaid()
        {
            // double ccBalance = 0;
            CreditCard cc = new CreditCard();

            double minDue = 256.34;
            double amountPaid = 175.45;
            double payDiff = minDue - amountPaid;
            double lateBalance = payDiff + 25;
            cc.UnderPaid(amountPaid, minDue);
            Assert.AreEqual(lateBalance, cc.CCNewCharge);
        }


        [TestMethod()] // Test #12  bank account overdrawn fee added
        public void OverDrawn()
        {
            BankAccount bank = new BankAccount();
            double bankBalance = 0;
            double withdraw = 25.00;
            double overDrawFee = 5.00;
            bankBalance = bankBalance - withdraw - overDrawFee;


            bank.OverDrawn(withdraw, overDrawFee);
            Assert.AreEqual(bankBalance, bank.Balance);
        }
    }
}
