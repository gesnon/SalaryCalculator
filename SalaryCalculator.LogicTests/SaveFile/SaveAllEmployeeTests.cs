using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCalculator.Logic.Models;
using SalaryCalculator.Logic.SaveFile;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Logic.SaveFile.Tests
{
    [TestClass()]
    public class SaveAllEmployeeTests
    {
        [TestMethod()]
        public void SaveTest()
        {
            List<BaseEmployee> employees = new List<BaseEmployee> { new Head("Иван", "3") };

            SaveAllEmployee saveAllEmployee = new SaveAllEmployee(employees);

            saveAllEmployee.Save();
        }
    }
}