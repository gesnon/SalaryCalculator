using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCalculator.Logic.Models;
using SalaryCalculator.Logic.SaveFile;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Logic.SaveFile.Tests
{
    [TestClass()]
    public class SaveHeadjournalTests
    {

        [TestMethod()]
        public void SaveTest()
        {
            List<TimeRecord> timeRecords = new List<TimeRecord> { new TimeRecord { FirstName="Иван",LastName= "2",Time= 8.5f,WorkingDate= new DateTime(2020,12,14),Comment= "задача-тест" } };

            SaveHeadjournal SaveHeadTime = new SaveHeadjournal(timeRecords);

            SaveHeadTime.Save();
        }
    }
}