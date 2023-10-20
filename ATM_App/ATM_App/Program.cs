using System;
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
        
        public static void Main(string[] args)
        {
            List<User> existingUsers = new List<User>();
            existingUsers.Add(new User("Pradeep Pallegama", 111111, 5555, 5000.57f));
            existingUsers.Add(new User("Danindu Weerasingha", 178000, 5555, 10000.57f));
            existingUsers.Add(new User("Saman Walisingha", 198000, 6666, 10000.57f));
            existingUsers.Add(new User("Danindu Weerasingha", 278000, 4444, 20000.57f));


            //PROMT USER
            Console.WriteLine("Welcome to SimpleATM");
            Console.WriteLine("Please enter your CardNo:");
            User currentUser;



            while (true)
            {
                int newCard = Convert.ToInt32(Console.ReadLine());
                currentUser = existingUsers.Find(user => user.CardNumber == newCard);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognised"); }
                
            }

            

            while (true)
            {
                Console.WriteLine("Please enter your PINNo:");
                int newPin = Convert.ToInt32(Console.ReadLine());
               // User isAValidPin = existingUsers.Find(user => user.Pin == newPin);
                if (currentUser.Pin == newPin) { break; }
                else { Console.WriteLine("Invalid Pin"); }

            }
            Console.WriteLine("Hellow!"+currentUser.Name);
            int newChoice = 0;
            
            
            do
            {
                printOptions();
                newChoice = Convert.ToInt32(Console.ReadLine());
                if (newChoice == 1) { deposit(currentUser); }
                else if (newChoice == 2) { withdraw(currentUser); }
                else if (newChoice == 3) { getBalance(currentUser); }
                else if (newChoice == 4) { break;}
                else newChoice = 0;

            } 
            while (newChoice != 4);
            Console.WriteLine("Thank you and have a nice day!");

            void printOptions()
            {
                Console.WriteLine("\n" +
                    "Please choose from onr of the following options..");
                Console.WriteLine("1.Deposit");
                Console.WriteLine("2.Withdraw");
                Console.WriteLine("3.Show Balance");
                Console.WriteLine("4. Exit");
            }

             void deposit(User user)
            {
                Console.WriteLine($"You have $ {user.Balance} in your account! ");
                Console.WriteLine("\nHow much $$ would you like to deposit: ");
                
                float depositNow = float.Parse(Console.ReadLine());
                user.Balance = depositNow;
                Console.WriteLine("Thank you for $$, your new balance is: " + user.Balance);
            }

            void withdraw(User user)
            {
                Console.WriteLine($"You have $ {user.Balance} in your account! ");
                Console.WriteLine("How much $$ would you like to witdraw: ");
                float withdrawNow = float.Parse(Console.ReadLine());
                if (user.checkWithdrawMoney(withdrawNow) != -1)
                {
                    Console.WriteLine("Innsufficent balance!");
                }
                else
                {
                    user.withdrawMoney(withdrawNow);
                    Console.WriteLine($"You have $ {user.Balance} in your account! ");
                    Console.WriteLine("\nyou are good to go!");
                }
            }

            void getBalance(User user)
            {
                Console.WriteLine("your balance is: " + user.Balance);
            }

        }


    }

}
