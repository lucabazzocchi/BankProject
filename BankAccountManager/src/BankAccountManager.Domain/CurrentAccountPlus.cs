using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManager.Domain
{
    public class CurrentAccountPlus : CurrentAccount
    {
        public List<AccountOperation> Operations { get; set; }

        public CurrentAccountPlus(Guid id, string name, double balance) : base(id, name, balance)
        {
            Operations = new List<AccountOperation>();

        }

        public void DepositOrWithdrawal(double amount)
        {
            if (amount < 0)
            {

                base.Withdrawal(amount);
                Operations.Add(new AccountOperation(amount, DateTime.Now));
            }
            else if (amount > 0)
            {
                base.Deposit(amount);
                Operations.Add(new AccountOperation(amount, DateTime.Now));
            }
            else
            {
                throw new InvalidOperationException("Cannot take 0 amount");

            }

        }


        public string MovementsList()
        {
            string movements = string.Empty;
            for (int i = 0; i < Operations.Count; i++)
            {
                movements += $"{Operations[i].OperationDescription}";
            }
            return movements;

        }

        public override string GetInformation()
        {
            return $"{base.GetInformation()}|{MovementsList()}";

        }


    }
}
