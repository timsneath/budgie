using System;
using Microsoft.Data.Entity;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using BudgieLibrary;
using System.Threading.Tasks;

namespace BudgieLibraryTest
{
    [TestClass]
    public class BudgetTests
    {
        //[ClassInitialize]
        public void CreateSampleBudget()
        {
            using (var budget = new BudgetContext())
            {
                budget.Database.Migrate();

                var checking = new Account(AccountType.Checking, "Test Checking Account");
                budget.Accounts.Add(checking);
                var savings = new Account(AccountType.Savings, "Test Savings Account");
                budget.Accounts.Add(savings);
                var creditCard = new Account(AccountType.CreditCard, "Test Credit Card");
                budget.Accounts.Add(creditCard);

                var housing = new Category(null, "Housing", null);
                budget.Categories.Add(housing);

                var mortgage = new Category(housing, "Mortgage", null);
                budget.Categories.Add(mortgage);
                var propertyTax = new Category(housing, "Property Tax", null);
                budget.Categories.Add(propertyTax);
                var insurance = new Category(housing, "Insurance", null);
                budget.Categories.Add(insurance);

                var transportation = new Category(null, "Transportation", null);
                budget.Categories.Add(transportation);
                var everydayExpenses = new Category(null, "Everyday Expenses", null);
                budget.Categories.Add(everydayExpenses);
                var savingsGoals = new Category(null, "Savings Goals", null);
                budget.Categories.Add(savingsGoals);

                var chaseBank = new Payee("Chase Bank");
                budget.Payees.Add(chaseBank);
                budget.Payees.Add(new Payee("Citibank"));
                budget.Payees.Add(new Payee("Bank of America"));
                budget.Payees.Add(new Payee("Shell"));
                budget.Payees.AddRange(new Payee[] {
                    new Payee("Texaco"),
                    new Payee("Chevrolet"),
                    new Payee("PEMCO Insurance"),
                    new Payee("Safeway"),
                    new Payee("Target"),
                    new Payee("New York Times"),
                    new Payee("Microsoft Corporation")
                    });

                budget.SaveChanges();
            }
        }

        [TestMethod]
        public void CategoriesCreatedSuccessfully()
        {
            this.CreateSampleBudget();

            using (var budget = new BudgetContext())
            {
                Assert.AreEqual(budget.Accounts.ToString(), "Budget");
            }

            this.DeleteSampleBudget();
        }

        [TestMethod]
        public void PayeesCreatedSuccessfully()
        {
        }

        //[ClassCleanup]
        public void DeleteSampleBudget()
        {
            using (var budget = new BudgetContext())
            {
                foreach (var transaction in budget.Transactions)
                {
                    budget.Transactions.Remove(transaction);
                }

                foreach (var category in budget.Categories)
                {
                    budget.Categories.Remove(category);
                }

                foreach (var account in budget.Accounts)
                {
                    budget.Accounts.Remove(account);
                }

                foreach(var payee in budget.Payees)
                {
                    budget.Payees.Remove(payee);
                }

                budget.SaveChanges();
            }
        }
    }
}
