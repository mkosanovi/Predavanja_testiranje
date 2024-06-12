using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesForTesting
{
    public abstract class BankAccount
    {
        public string AccountNumber { get; private set; }
        public string Owner { get; private set; }
        public decimal Balance { get; protected set; }
        protected List<Transaction> transactions;

        public BankAccount(string accountNumber, string owner, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = initialBalance;
            transactions = new List<Transaction>();
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive");

            var transaction = new Transaction(amount, DateTime.Now, "Deposit");
            transactions.Add(transaction);
            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdraw amount must be positive");
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds");

            var transaction = new Transaction(-amount, DateTime.Now, "Withdraw");
            transactions.Add(transaction);
            Balance -= amount;
        }

        public IEnumerable<Transaction> GetTransactions() => transactions;

        public abstract void PerformMonthEndTransactions();
    }
}
