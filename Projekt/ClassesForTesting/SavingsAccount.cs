using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesForTesting
{
    public class SavingsAccount : BankAccount
    {
        private decimal interestRate;

        public SavingsAccount(string accountNumber, string owner, decimal initialBalance, decimal interestRate)
            : base(accountNumber, owner, initialBalance)
        {
            this.interestRate = interestRate;
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 0)
            {
                var interest = Balance * interestRate;
                Deposit(interest);
            }
        }
    }
}
