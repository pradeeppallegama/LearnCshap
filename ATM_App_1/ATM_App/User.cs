using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_App
{
    public class User
    {
        //getters & setters
       public string Name { get; set; }
       public int CardNumber { get; set; }
       public int Pin { get; set; }
        private float _balance;
       public float Balance
        {
            get{return _balance;}

            set{ _balance += value;}
        }

        //Constructor
       public User(string name, int cardno, int pin, float balance)
       {

            this.Name = name;
            this.CardNumber = cardno;
            this.Pin = (pin > 0) ? pin : throw new ArgumentException("Card number and PIN must be non-negative.");
            this._balance = balance;
       }

        public int CheckWithdrawMoney(double amount)
        {
            if (this._balance > amount)
            {
                return -1;
            }
            else
            {
                return 1;
            }
                
        }

        public void WithdrawMoney(float amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than 0.");
            }
            if (amount > _balance)
            {
                throw new InvalidOperationException("Insufficient balance to withdraw.");
            }

            try
            {
                _balance -= amount;
            }
            catch (Exception)
            {

                Console.WriteLine($"An error occurred while withdrawing money: {ex.Message}");
            }
           
        }

    }
}
