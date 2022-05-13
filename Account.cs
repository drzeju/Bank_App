using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_App
{
    class Account
    {
        public long accountNumber { get; }
        public int userId { get; }
        Currency currency;
        private decimal balance;
        public bool blocked;
        //User user;
        
        public Account(long accountNumber, int userId, Currency currency, decimal balance, bool blocked)
        {
            this.accountNumber = accountNumber;
            this.userId = userId;
            this.currency = currency;
            this.balance = balance;
            this.blocked = blocked;
            //this.user = user;
        }

        public void PrintAccount()
        {
            Console.WriteLine("no: " + accountNumber);

        }

        public void PrintAccountDetails()
        {
            Console.WriteLine("no: " + accountNumber + " balance: " + balance + " " + currency);
            
        }

        public void Deposit(int amount)
        {
            balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (blocked == true)
                Console.WriteLine("Konto zajęte przez służby.");
            else
                balance -= amount;
        }
    }
}
