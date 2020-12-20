using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCalculator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Logic.Models.Tests
{
    [TestClass()]
    public class HeadTests
    {
        [TestMethod()]
        public void CreateEmployeeTest()
        {
            Head testHead = new Head("тест имя", "тест Фамилия");

            testHead.CreateEmployee("фрилансер 1 имя", "фрилансер 1 фамилия", EmployeeType.Freelanser);
        }
    }
}