using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesForTesting
{
    public class CheckingAccount : BankAccount
    {
        private decimal overdraftLimit;

        public CheckingAccount(string accountNumber, string owner, decimal initialBalance, decimal overdraftLimit)
            : base(accountNumber, owner, initialBalance)
        {
            this.overdraftLimit = overdraftLimit;
        }

        public override void PerformMonthEndTransactions()
        {
            // No specific month end transactions for CheckingAccount
        }

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdraw amount must be positive");
            if (amount > (Balance + overdraftLimit))
                throw new InvalidOperationException("Insufficient funds, including overdraft limit");

            var transaction = new Transaction(-amount, DateTime.Now, "Withdraw");
            transactions.Add(transaction);
            Balance -= amount;
        }
    }
}
