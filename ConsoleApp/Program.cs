﻿// See https://aka.ms/new-console-template for more information
using Models;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Menu
            BankAccount[] bankAccounts = new BankAccount[10];
            int index = 0;
            bool choice = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Create new account");
                Console.WriteLine("2. Search an existing account");
                Console.WriteLine("3. Show all accounts");

                string option = Console.ReadLine();
                string title, accountType, code;
                BankAccount bankAccount = null;

                switch (option)
                {
                    case "1":
                        #region Create New Account
                        Console.Clear();
                        // input all data
                        Console.WriteLine("Enter the account title");
                        title = Console.ReadLine().Trim();

                        Console.WriteLine("Select the account type. 1) Saving 2) Current");
                        accountType = Console.ReadLine().Trim();

                        if (accountType == "1")
                        {
                            bankAccount = new SavingBankAccount
                            {
                                Title = title,
                            };
                        }
                        else if (accountType == "2")
                        {
                            bankAccount = new CurrentBankAccount
                            {
                                Title = title,
                            };
                        }

                        if (bankAccount != null)
                        {
                            bankAccounts[index] = bankAccount;
                            index += 1;
                            Console.WriteLine("Account created");
                            Console.WriteLine(bankAccount);
                        }
                        Console.WriteLine("Press any key for main menu");
                        Console.ReadKey();
                        #endregion
                        break;
                    case "2":
                        #region Search an existing account
                        Console.Clear();
                        Console.WriteLine("Enter the account code");
                        code = Console.ReadLine().Trim();

                        Console.WriteLine($"Total accounts: {BankAccount.Total}");
                        BankAccountIteration(bankAccounts, index, code);
                        Console.WriteLine("Press any key for main menu");
                        Console.ReadKey();
                        #endregion
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine($"Total accounts: {BankAccount.Total}");
                        foreach (var item in bankAccounts)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Press any key for main menu");
                        Console.ReadKey();
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    default:
                        choice = false;
                        break;
                }

            } while (choice);
        }

        private static void BankAccountIteration(BankAccount[] bankAccounts, int index, string code)
        {
            for (int i = 0; i < index; i++)
            {
                if (string.Compare(bankAccounts[i].Code, code) == 0)
                {
                    Console.WriteLine(bankAccounts[i]);
                    break;
                }
            }
        }
    }
}
