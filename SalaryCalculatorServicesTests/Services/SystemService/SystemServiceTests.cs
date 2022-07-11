using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCalculatorServices.Services.SystemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.SystemService.Tests
{
    [TestClass()]
    public class SystemServiceTests
    {
        SystemService systemService = new SystemService();
        [TestMethod()]
        public void CheckAllCharIsLetter()
        {
            string name = "Сергей";
            bool check = systemService.CheckNameValid(name);
            Assert.IsTrue(check);
        }
        [TestMethod()]
        public void NameContainNumbers()
        {
            string name = "Сер123";
            bool check = systemService.CheckNameValid(name);
            Assert.IsFalse(check);
        }

        [TestMethod()]
        public void NameContainSpecialSymbol()
        {
            string name = "Панкратов-Иванов";
            bool check = systemService.CheckNameValid(name);
            Assert.IsTrue(check);
        }
    }
}