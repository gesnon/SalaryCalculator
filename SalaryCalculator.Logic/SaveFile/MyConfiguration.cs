using CsvHelper.Configuration;
using SalaryCalculator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SalaryCalculator.Logic.SaveFile
{
    public class MyConfiguration: ClassMap<BaseEmployee>
    {
        public MyConfiguration()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(q => q.FirstName).Name("Имя");
            Map(q => q.LastName).Name("Фамилия");
            Map(q => q.Type).Name("Должность");
            Map(q => q.Bonus).Ignore();
            Map(q => q.Salary).Ignore();
        }
    }
}
