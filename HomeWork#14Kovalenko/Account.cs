using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_14Kovalenko
{
   public class Account
    {       
      

        public Account( string nameAccount, decimal balance)
        {
         
            this.Balance = balance;
            this.NameAccount = nameAccount;
        }
        public decimal Balance { get; set; }
        public string NameAccount { get; set; }
    }    

      
}
