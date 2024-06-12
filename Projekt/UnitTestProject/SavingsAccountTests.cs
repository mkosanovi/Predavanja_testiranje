using ClassesForTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class SavingsAccountTests
    {
        private SavingsAccount account;

        public void SetUp()
        {
            account = new SavingsAccount("123456", "Jane Doe", 1000m, 0.05m);
        }

        [TestMethod]
        public void PerformMonthEndTransactions_InterestIsApplied()
        {
            SetUp();
            account.PerformMonthEndTransactions();
            Assert.AreEqual(1050m, account.Balance);
        }

        [TestMethod]
        public void PerformMonthEndTransactions_NoInterestIfBalanceIsZero()
        {
            SetUp();
            account.Withdraw(1000m);
            account.PerformMonthEndTransactions();
            Assert.AreEqual(0m, account.Balance);
        }

        [TestMethod]
        public void Deposit_ValidAmount_UpdatesBalance()
        {
            SetUp();
            account.Deposit(500m);
            Assert.AreEqual(1500m, account.Balance);
        }

        [TestMethod]
        public void Withdraw_ValidAmount_UpdatesBalance()
        {
            SetUp();
            account.Withdraw(200m);
            Assert.AreEqual(800m, account.Balance);
        }

        [TestMethod]
        public void GetTransactions_ReturnsAllTransactions()
        {
            SetUp();
            account.Deposit(500m);
            account.Withdraw(200m);
            var transactions = account.GetTransactions();
            Assert.AreEqual(2, ((List<Transaction>)transactions).Count);
        }

        [TestMethod]
        public void InitialBalance_IsSetCorrectly()
        {
            SetUp();
            Assert.AreEqual(1000m, account.Balance);
        }

        [TestMethod]
        public void AccountNumber_IsSetCorrectly()
        {
            SetUp();
            Assert.AreEqual("123456", account.AccountNumber);
        }
    }
}
