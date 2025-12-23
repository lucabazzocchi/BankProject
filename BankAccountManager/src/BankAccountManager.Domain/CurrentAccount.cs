namespace BankAccountManager.Domain
{
    public class CurrentAccount
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        protected double Balance { get; set; }
        protected AccountStatus status { get; set; }
        
        
        public CurrentAccount(Guid id, string name, double balance)
        {
            Id = id;
            Name = name;
            Balance = balance;
            status = new AccountStatus();

        }


        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;

            Balance += amount;
            return true;
        }



        public virtual bool Withdrawal(double amount)
        {
            if (amount < 0)
                return false;
            if (amount > Balance)
                return false;
            Balance -= amount;
            return true;

        }

        public void AddInterests()
        {
            if (Balance >= 100 && Balance <= 1000)
            {
                Balance = Balance + Balance * 0.02;
            }
            else if (Balance > 1000)
            {
                Balance = Balance + Balance * 0.04;
            }

        }

        public AccountStatus Status()
        {

            if (Balance == 0)
            {
                status = AccountStatus.Empty;
            }
            else if (Balance > 0)
            {
                status = AccountStatus.Positive;
            }
            else
            {
                status = AccountStatus.Negative;
            }

            return status;
        }

        


        public virtual string GetInformation()
        {
            return $"{Name.ToString()} | {Id.ToString()} | {Status()}|{Balance.ToString()}";
        }
    }
}
