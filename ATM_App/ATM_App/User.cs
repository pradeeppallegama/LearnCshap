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
            get
            {
                return _balance;

            }

            set
            {
                _balance += value;
            }
        }

        //Constructor
       public User(string Name, int CNo, int PNo, float ABalance)
       {
            this.Name = Name;
            this.CardNumber = CNo;
            this.Pin = PNo;
            this._balance = ABalance;
       }

        public int checkWithdrawMoney(double amount)
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

        public void withdrawMoney(float amount)
        {
            _balance  -= amount;
           
        }

    }
}
