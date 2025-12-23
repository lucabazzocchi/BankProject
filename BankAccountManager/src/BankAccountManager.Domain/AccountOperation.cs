using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManager.Domain
{
    public class AccountOperation
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        private string OperationType { get; set; }


        public AccountOperation(double amount, DateTime date)
        {
            Amount = amount;
            Date = date;

            if (Amount > 0)
                OperationType = "Deposit";
            else if (Amount < 0)
                OperationType = "Withdrawal";
            else
                throw new InvalidOperationException("Amount cannot be 0");
        }



        public string Description => $"{Amount} - {Date} - {OperationType}";




    }
}
