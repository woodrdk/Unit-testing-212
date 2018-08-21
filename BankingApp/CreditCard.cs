using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class CreditCard
    {
        public CreditCard()
            : this(0, null)
        {

        }

        public CreditCard(double initialBalance)
            : this(initialBalance, null)
        {

        }

        public CreditCard(double initialBalance, string AccNumber)
        {
            CCBalance = initialBalance;
            CCAccountNumber = AccNumber;
        }

        public double CCBalance { get; private set; }
        public double CCOverpay { get; private set; }
        public double CCPayDiff { get; private set; }
        public string CCAccountNumber { get; set; }
        public double CCNewCharge { get; set; }
        public string CCAccountHolder { get; set; }

        public double Deposit(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("You cannot deposit a negative amount");

            CCBalance -= amount;
            return CCBalance;
        }

        public double Withdraw(double amount)
        {
            CCBalance += amount;
            return CCBalance;
        }

        public double CashAdvance(double amount, double interest)
        {
            CCBalance = CCBalance + amount + (amount * interest);
            return CCBalance;
        }

        public double InterestDeposit(double amount, double interest)
        {
           
            CCBalance = ((CCBalance * interest) + CCBalance) - amount;
            return CCBalance;
        }

        public double InterestDepositWOneTime(double amount,double minDue )
        {
            CCOverpay = amount - minDue;
           
            return CCOverpay;
        }

        public string PaidOff(double amountPaid)
        {
            CCBalance = amountPaid - CCBalance;

            if ((CCBalance) == 0)
            {
                return "You Owe Nothing";
            }
            else
            {
                return (amountPaid - CCBalance).ToString();
            }
        }

        public double OverPaid(double amountPaid)
        {
            CCBalance = CCBalance - amountPaid ;

            if ( CCBalance < 0)
            {
               return -CCBalance;
            }
            else
            {
                return CCBalance;
            }
        }

        public bool CCHolder_Name(string AccountHolder)
        {
            CCAccountHolder = "User";
            if (CCAccountHolder == AccountHolder)
            {
                return true;
            }
            return false;
        }


        public double UnderPaid(double amountPaid, double minDue)
        {
            CCPayDiff = minDue - amountPaid;
            double lateFee = 25;
            //double newCharge = 0;
            if (CCPayDiff > 0)
            {
                CCNewCharge =  CCPayDiff + lateFee;
                return CCNewCharge;
            }
            else
            {
                return CCNewCharge;
            }
        }

   
    }

}
