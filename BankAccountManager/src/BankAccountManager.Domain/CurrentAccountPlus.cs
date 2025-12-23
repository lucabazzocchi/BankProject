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
            if (amount == 0) throw new InvalidOperationException("Cannot verify 0 amount");

            if (amount < 0)
            {
                // FIX: Usiamo Math.Abs perché Withdrawal si aspetta un numero positivo da sottrarre
                // Esempio: Se amount è -50, noi proviamo a prelevare 50.
                bool success = base.Withdrawal(Math.Abs(amount));

                if (success)
                {
                    // Registriamo l'operazione con il segno originale (-50) per lo storico
                    Operations.Add(new AccountOperation(amount, DateTime.Now));
                }
                else
                {
                    throw new InvalidOperationException("Saldo insufficiente o importo non valido");
                }
            }
            else // amount > 0
            {
                base.Deposit(amount);
                Operations.Add(new AccountOperation(amount, DateTime.Now));
            }
        }

        // Per il Web, è meglio restituire direttamente la lista Operations (che diventerà un array JSON)
        // piuttosto che una stringa concatenata. Ma mantengo il tuo metodo formattato per coerenza.
        public string MovementsList()
        {
            string movements = "";
            foreach (var op in Operations)
            {
                movements += $"{op.Description}\n";
            }
            return movements;
        }
    }
}
