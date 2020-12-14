using CsvHelper;
using SalaryCalculator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SalaryCalculator.Logic.SaveFile
{
    public class SaveAllEmployee
    {
        public List<BaseEmployee> employees { get; set; }

        public SaveAllEmployee(List<BaseEmployee> employees)
        {
            this.employees = employees;
        }
        public void Save()
        {
            using (var writer = new StreamWriter(@"C:\Programs\MVS2019\Microsoft Visual Studio\SaveFile\Employee.csv",true,Encoding.Unicode))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {                
                csv.Configuration.RegisterClassMap<MyConfiguration>();

                csv.WriteRecords(employees);
            }
        }
    }

}
