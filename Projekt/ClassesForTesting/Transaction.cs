using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesForTesting
{
    public class Transaction
    {
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string Notes { get; private set; }

        public Transaction(decimal amount, DateTime date, string notes)
        {
            Amount = amount;
            Date = date;
            Notes = notes;
        }
    }
}
