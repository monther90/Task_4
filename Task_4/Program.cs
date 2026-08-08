namespace Task_4
{
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                Balance += amount;
                return true;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class SavingAccount : Account
    {
        public double InterestRate { get; set; }
        public SavingAccount(string name = "Unnamed Account", double balance = 0.0,  double interestRate = 0.0): base(name, balance)
        {
            InterestRate = interestRate;
        }
        public override bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
               double interest = (amount * InterestRate) / 100;
                amount += interest;
                Balance += amount;
                return true;
            }
        }

    }
    public class CheckingAccount : Account
    {
        private const double Fee = 1.50;
        public CheckingAccount(string name = "Unnamed Account",double balance = 0.0): base(name, balance){}
        public override bool Withdraw(double amount)
        {
            if (Balance - amount - Fee >= 0)
            {
                amount += Fee;
                Balance -= amount;
                //Balance -= Fee;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class TrustAccount : Account
    {
        public double InterestRate { get; set; }
        public TrustAccount (string name = "Unnamed Account", double balance = 0.0, double interestRate = 0.0) : base(name, balance)
        {
            InterestRate = interestRate;
        }
        private int WithdrawalsCount = 0;
        public override bool Withdraw(double amount)
        {
            double checkamount = (Balance * 20) / 100;
            if (WithdrawalsCount >= 3 || Balance - amount < 0 || amount >= checkamount)
            {
                return false;
            }
            else
            {
                Balance -= amount;
                WithdrawalsCount++;
                return true;
            }
        }
             private const double bouns = 50.0;
        public override bool Deposit(double amount)
        { 
            double depositAmount = amount;
            if (amount < 0)
                return false;
            else
            {
                double Interest = (amount * InterestRate) / 100;
                amount += Interest;

                if (depositAmount >= 5000) amount += bouns;

                Balance += amount; 

                    return true;
            }
        }


    }
    public static class AccountUtil
    {
        // Utility helper functions for Account class
        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // Accounts
            var accounts = new List<Account>();
            accounts.Add(new Account());
            accounts.Add(new Account("Larry"));
            accounts.Add(new Account("Moe", 2000));
            accounts.Add(new Account("Curly", 5000));

            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Saving انا غيرت اسم الكلاس و شلت حرف s
            var savAccounts = new List<Account>();
            savAccounts.Add(new SavingAccount());
            savAccounts.Add(new SavingAccount("Superman"));
            savAccounts.Add(new SavingAccount("Batman", 2000));
            savAccounts.Add(new SavingAccount("Wonderwoman", 5000, 5.0));

            AccountUtil.Deposit(savAccounts, 1000);
            AccountUtil.Withdraw(savAccounts, 2000);

            // Checking
            var checAccounts = new List<Account>();
            checAccounts.Add(new CheckingAccount());
            checAccounts.Add(new CheckingAccount("Larry2"));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.Deposit(checAccounts, 1000);
            AccountUtil.Withdraw(checAccounts, 2000);
            AccountUtil.Withdraw(checAccounts, 2000);

            // Trust
            var trustAccounts = new List<Account>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

            AccountUtil.Deposit(trustAccounts, 1000);
            AccountUtil.Deposit(trustAccounts, 6000);
            AccountUtil.Withdraw(trustAccounts, 2000);
            AccountUtil.Withdraw(trustAccounts, 3000);
            AccountUtil.Withdraw(trustAccounts, 500);

            Console.WriteLine();

        }
    }
}
