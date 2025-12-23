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

        private string operationType { get; set; }


        public AccountOperation(double amount, DateTime date)
        {
            Amount = amount;
            Date = date;
            operationType = string.Empty;
            OperationType();
        }

        public string OperationType()
        {

            if (Amount > 0)
            {
                operationType = "Deposit";
            }
            else if (Amount < 0)
            {
                operationType = "Withdrawal";
            }
            else
            {
                throw new InvalidOperationException("amount cannot be 0");
            }
            return operationType;

        }

        public string OperationDescription() => Amount.ToString() + " - " + Date.ToString() + " - " + operationType;




    }
}
