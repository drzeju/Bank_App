using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bank_App
{
    class Reader
    {
        public static List<User> readUsersFromFile(string file)
        {
            return File.ReadAllLines(file).Skip(1).Select(v => createUser(v)).ToList();
        }

        public static User createUser(string row)
        {
            string[] values = row.Split(";");
            User user = new User(Int16.Parse(values[0]), values[1], values[2], Int64.Parse(values[3]), values[4]);

            return user;
        }

        //---------------------------------------------------------------------------------------------------

        public static List<Account> readAccountsFromFile(string file)
        {
            return File.ReadAllLines(file).Skip(1).Select(v => createAccount(v)).ToList();
        }

        public static Account createAccount(string row)
        {
            string[] values = row.Split(";");
            Currency currency;
            Enum.TryParse<Currency>(values[2], out currency);
            bool blocked = false;
            if(values[4] == "TAK")
            {
                blocked = true;
            }
            Account account = new Account(Int64.Parse(values[0]), Int32.Parse(values[1]), currency, Decimal.Parse(values[3]), blocked);

            return account;
        }
    }
}

//int accountNumber, int userId, Currency currency, decimal balance, bool blocked
