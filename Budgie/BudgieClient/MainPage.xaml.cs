using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BudgieLibrary;
using Microsoft.Data.Entity;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BudgieClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
            }
        }
    }
}
