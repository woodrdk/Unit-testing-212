using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class BankAccount
    {
        public BankAccount()
            : this(0 , null)
        {

        }

        public BankAccount(double initialBalance)
            : this(initialBalance, null)
        {
           
        }

        public BankAccount(double initialBalance, string AccNumber)
        {
            Balance = initialBalance;
            AccountNumber = AccNumber;
        }

        public double Balance { get; private set; }

        public string AccountNumber { get; set; }

        public string AccountHolder { get; set; }

        /// <summary>
        /// Deposit amount and adds to balance
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Existing balance plus deposit amount</returns>
        public double Deposit(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("You cannot deposit a negative amount");

            Balance += amount;
            return Balance;
        }

        public double Withdraw(double amount)
        {
            Balance -= amount;
            return Balance;
        }
    }
}
