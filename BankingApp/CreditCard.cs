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

        public string CCAccountNumber { get; set; }

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
    }

}
