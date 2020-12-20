using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCalculator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Logic.Models.Tests
{
    [TestClass()]
    public class JournalTests
    {
        [TestMethod()]
        public void AddWorkTimeTest()
        {
            Journal testJournal = new Journal();

            testJournal.AddWorkTime(new Freelancer("Иван", "3"), 7.5f, new DateTime(2020, 12, 16), "запись 1");
        }

        [TestMethod()]
        public void AddWorkTimeTest1()
        {
            Assert.Fail();
        }
    }
}
