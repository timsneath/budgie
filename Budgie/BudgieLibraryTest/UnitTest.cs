using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using BudgieLibrary;

namespace BudgieLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateBudget()
        {
            var budget = new BudgetContext();
        }
    }
}
