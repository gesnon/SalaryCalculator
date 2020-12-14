using CsvHelper.Configuration;
using SalaryCalculator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SalaryCalculator.Logic.SaveFile
{
    public class MyConfigForHeadJournal: ClassMap<TimeRecord>
    {
        public MyConfigForHeadJournal()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(q => q.WorkingDate).Name("Дата работы").Index(1);
            Map(q => q.FirstName).Name("Имя").Index(2);
            Map(q => q.LastName).Name("Фамилия").Index(3);
            Map(q => q.Time).Name("Часы").Index(4);
            Map(q => q.Comment).Name("Задача").Index(5);
            Map(q => q.DateOfRecord).Ignore();
        }
    }
}
