using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManager.Domain
{
    public class Bank
    {
        public List<CurrentAccount> Accounts { get; set; }
        const double standardBalance = 0;
        Guid id { get; set; }
        public Bank()
        {
            Accounts = new List<CurrentAccount>();
        }

        public void CreateAccount(Guid id, string name)
        {

            Accounts.Add(new CurrentAccount(id, name, standardBalance));
        }

        public void CreateAccountPlus(Guid id, string name)
        {

            Accounts.Add(new CurrentAccountPlus(id, name, standardBalance));
        }

        public string GetInformationById(Guid guid)
        {
            string informations = string.Empty;
            for (int i = 0; i < Accounts.Count; i++)
            {
                if (guid == Accounts[i].Id)
                {
                    informations = Accounts[i].GetInformation();
                    break;
                }

            }
            return informations;
        }

        public string GetBiggerHolder()
        {
            List<string> Holders = new List<string>();
            List<int> Counters = new List<int>();
            string biggerHolder = string.Empty;
            for (int i = 0; i < Accounts.Count; i++)
            {
                if (Holders.Contains(Accounts[i].Name))
                {
                    int index = Holders.IndexOf(Accounts[i].Name);
                    Counters[index] += 1;
                }
                else
                {
                    Holders.Add(Accounts[i].Name);
                    Counters.Add(1);
                }

            }
            int maxIndex = Counters.IndexOf(Counters.Max());
            return Holders[maxIndex];
        }

        public string getBiggerHolder()
        {
            List<string> Holders = new List<string>();
            List<int> Counters = new List<int>();
            foreach (var a in Accounts)
            {
                if (Holders.Contains(a.Name))
                {
                    int indx = Accounts.IndexOf(a);
                    Counters[indx]++;
                }
                else
                {
                    Holders.Add(a.Name);
                    Counters.Add(1);
                }
            }
            int maxIndex = 0;
            foreach (var c in Counters)
            {
                if (c > maxIndex)
                {
                    maxIndex = c;
                }
            }
            return Holders[maxIndex];
        }

        public string findMaxPlus()
        {
            List<CurrentAccountPlus> pluses = new List<CurrentAccountPlus>();
            int maxValue = 0;
            string maxPlusOperations = "";
            foreach (var a in Accounts)
            {
                if (a is CurrentAccountPlus)
                {
                    pluses.Add((CurrentAccountPlus)a);
                }
            }
            foreach (var c in pluses)
            {
                if (c.Operations.Count > maxValue)
                {
                    maxValue = c.Operations.Count;
                    maxPlusOperations = c.Name;
                }

            }
            return maxPlusOperations;
        }
    }
}
