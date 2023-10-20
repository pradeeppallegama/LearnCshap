using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ATM_App
{
    internal class Program
    {
        public static void PrintOption()
        {
            Console.WriteLine("\n" +
                "Please choose from onr of the following options..");
            Console.WriteLine("1.Deposit");
            Console.WriteLine("2.Withdraw");
            Console.WriteLine("3.Show Balance");
            Console.WriteLine("4. Exit");
        }

        public static void Deposit(User user)
        {
            Console.WriteLine($"You have $ {user.Balance} in your account! ");
            Console.WriteLine("\nHow much $$ would you like to deposit: ");

            try
            {
                float depositNow = float.Parse(Console.ReadLine());
                user.Balance = depositNow;
                Console.WriteLine("Thank you for $$, your new balance is: " + user.Balance);
            }
            catch (FormatException)
            {

                Console.WriteLine("Invalid input. Please enter a valid Deposit Ammount.");
            }
        }

        public static void Withdraw(User user)
        {
            Console.WriteLine($"You have $ {user.Balance} in your account! ");
            Console.WriteLine("How much $$ would you like to witdraw: ");

            try
            {
                float withdrawNow = float.Parse(Console.ReadLine());
                if (user.CheckWithdrawMoney(withdrawNow) != -1)
                {
                    Console.WriteLine("Innsufficent balance!");
                }
                else
                {
                    user.WithdrawMoney(withdrawNow);
                    Console.WriteLine($"You have $ {user.Balance} in your account! ");
                    Console.WriteLine("\nyou are good to go!");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid input. Please enter a valid Deposit withdraw ammount.");
            }
        }
        public static void GetBalance(User user)
        {
            Console.WriteLine("your balance is: " + user.Balance);
        }

        public static void Main(string[] args)
        {
            List<User> existingUsers = new List<User>();
            existingUsers.Add(new User("Pradeep Pallegama", 111111, 5555, 5000.57f));
            existingUsers.Add(new User("Danindu Weerasingha", 178000, 5555, 10000.57f));
            existingUsers.Add(new User("Saman Walisingha", 198000, 6666, 10000.57f));
            existingUsers.Add(new User("Danindu Weerasingha", 278000, 4444, 20000.57f));


            //PROMT USER
            Console.WriteLine("Welcome to SimpleATM");
           
            User currentUser;


            // CHECK VALID USER
            while (true)
            {
                Console.WriteLine("Please enter your CardNo:");
                try
                {
                    int newCard = Convert.ToInt32(Console.ReadLine());
                    currentUser = existingUsers.Find(user => user.CardNumber == newCard);
                    if (currentUser != null) { break; }
                    else { Console.WriteLine("Card not recognised"); }
                }
                catch (Exception e)
                {

                    Console.WriteLine("Invalid input. Please enter a valid number for your card. Message: "+e.Message) ;
                    Console.WriteLine(e.StackTrace);
                }
                
            }

            
            //CHECK VALID PIN
            while (true)
            {
                Console.WriteLine("Please enter your PINNo:");
                try
                {
                    int newPin = Convert.ToInt32(Console.ReadLine());
                    if (currentUser.Pin == newPin) { break; }
                    else { Console.WriteLine("Invalid Pin"); }
                }
                catch (FormatException e)
                {

                    Console.WriteLine("Invalid input. Please enter a valid number for your card. Message: " + e.Message);
                    Console.WriteLine(e.StackTrace);
                }

            }
            Console.WriteLine("Hellow!"+currentUser.Name);
            int newChoice = 0;
            
            //MENUE
            do
            {
                PrintOption();
                try
                {

                    newChoice = Convert.ToInt32(Console.ReadLine());
                    if (newChoice == 1) { Deposit(currentUser); }
                    else if (newChoice == 2) { Withdraw(currentUser); }
                    else if (newChoice == 3) { GetBalance(currentUser); }
                    else if (newChoice == 4) { break; }
                    else newChoice = 0;
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid input. Please enter a valid number for your choice.");
                }

            } 
            while (newChoice != 4);
            Console.WriteLine("Thank you and have a nice day!");

        }


    }

}
