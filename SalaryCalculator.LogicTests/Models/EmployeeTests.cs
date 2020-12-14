using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCalculator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SalaryCalculator.Logic.Models.Tests
{
    [TestClass()]
    public class EmployeeTests
    {
        [TestMethod()]
        public void AddWorkTimeTest()
        {
            Employee testEmployee = new Employee("Иван", "Иванов");
            Journal testJournal = new Journal();
            testJournal.TimeJournal = new List<TimeRecord>();
            testEmployee.AddWorkTime(testJournal,testEmployee,8, new DateTime(2020,11,21),"Тестовая запись");
            Assert.IsTrue(testJournal.TimeJournal.Count != 0);
            Assert.AreEqual("Тестовая запись", testJournal.TimeJournal[0].Comment);
        }

        [TestMethod()]
        public void GetPersonalTimeRecordsTest()
        {            
            Employee testEmployee = new Employee("Иван", "Иванов");
            Journal testJournal = new Journal();
            testJournal.TimeJournal = new List<TimeRecord>();
            testEmployee.AddWorkTime(testJournal, testEmployee, 8.12f, new DateTime(2020, 11, 21), "Тестовая запись");
             var testTimeRecord = testEmployee.GetPersonalTimeRecords(testEmployee, new DateTime(2020,11,19), new DateTime(2020, 11, 21),testJournal);
            Assert.AreEqual(8,testTimeRecord[0].Time);
        }

        [TestMethod()]
        public void JournalLength()
        {
            Employee testEmployee = new Employee("Иван", "Иванов");
            Journal testJournal = new Journal();
            testJournal.TimeJournal = new List<TimeRecord>();
            testEmployee.AddWorkTime(testJournal, testEmployee, 8.13f, new DateTime(2020, 11, 20), "Тестовая запись");
            testEmployee.AddWorkTime(testJournal, testEmployee, 7.5f, new DateTime(2020, 11, 21), "Тестовая запись");
            Assert.AreEqual(2, testJournal.TimeJournal.Count);
        }

        [TestMethod()]
        public void GetSalary()
        {
            Employee testEmployee = new Employee("Иван", "Иванов");
            Journal testJournal = new Journal();
            testJournal.TimeJournal = new List<TimeRecord>();
            testEmployee.AddWorkTime(testJournal, testEmployee, 8.13f, new DateTime(2020, 11, 20), "Тестовая запись");
            testEmployee.AddWorkTime(testJournal, testEmployee, 7.5f, new DateTime(2020, 11, 21), "Тестовая запись");
            Assert.AreEqual(11722.5, testEmployee.GetSalary(testEmployee, new DateTime(2020, 11, 19), new DateTime(2020, 11, 22),testJournal));
        }



    }
}