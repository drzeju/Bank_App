using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bank_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string currentDir = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDir);

            //ReadAllLines

            List<User> users = Reader.readUsersFromFile("osoby.csv");
            Console.WriteLine(users.Count);
                    

            List<Account> accounts = Reader.readAccountsFromFile("konta.csv");
            Console.WriteLine(accounts.Count);

            Console.WriteLine();
            Console.WriteLine();


            foreach (User user in users)
            {
                IEnumerable<Account> userAccounts = accounts.Where(a => a.userId == user.id);
                user.AddAccounts(userAccounts.ToList());
            }


            PrintUserAccounts(users[2]);
            Console.WriteLine();
            Console.WriteLine();

            users[2].UserWithdrawCash(34523412123, 200000);
            Console.WriteLine();
            PrintUserAccounts(users[2]);
            Console.WriteLine();
            Console.WriteLine();

            PrintBlockedAccounts(users);
            Console.WriteLine();
            Console.WriteLine();


            PrintRaport(users);

        }


        public static void PrintUserAccounts(User user)
        {
            user.PrintUserAccounts();
        }

        public  static void PrintBlockedAccounts(List<User> users)
        {
            IEnumerable<User> bUsers = users.Where(a => a.HasAccount());
            foreach (User user in bUsers)
            {
                user.PrintUserBlockedAccounts();
            }
        }

        public static void PrintRaport(List<User> users)
        {
            foreach(User user in users)
            {
                user.PrintUserAccounts();
            }


        }

    }
}
