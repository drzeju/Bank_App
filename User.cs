using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank_App
{
    class User
    {
        public int id { get; }
        private string name;
        private string surname;
        private readonly long pesel;
        private string address;

        private List<Account> userAccounts = new List<Account>();

        public User(int id, string name, string surname, long pesel, string address)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.pesel = pesel;
            this.address = address;
        }


        public void AddAccounts(List<Account> accounts)
        {
            userAccounts = accounts;
        }



        public void PrintUserAccounts()
        {
            Console.WriteLine("User " + id + " " + name + " " + surname + " Accounts:");
            
            foreach(Account account in userAccounts)
            {
                account.PrintAccountDetails();
            }
        }

       
        public void UserDepositCash(long accountNumber, int amount)
        {
            List<Account> accounts1 = userAccounts.Where(x => x.accountNumber == accountNumber).ToList();
            if (accounts1.Count > 0)
                accounts1[0].Deposit(amount);
        }

        public void UserWithdrawCash(long accountNumber, int amount)
        {
            List<Account> accounts1 = userAccounts.Where(x => x.accountNumber == accountNumber).ToList();
            if (accounts1.Count > 0)
                accounts1[0].Withdraw(amount);
        }



        public void PrintUserBlockedAccounts()
        {
            Console.WriteLine("User " + id + " " + name + " " + surname + " Blocked accounts:");

            IEnumerable<Account> blockedAccounts = userAccounts.Where(a => a.blocked);
            foreach (Account account in  blockedAccounts)
            {
                account.PrintAccount();
            }
        }

        public bool HasAccount()
        {
            return userAccounts.Count > 0;
        }
    }
}
