using CsvHelper;
using SalaryCalculator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SalaryCalculator.Logic.SaveFile
{
    public class SaveToFile
    {
        public void Save<T>(string PathToFile, T Record)
        {
            using (var writer = new StreamWriter(PathToFile, true, Encoding.Unicode))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<MyConfigForHeadJournal>();
                csv.Configuration.RegisterClassMap<MyConfiguration>();

                csv.WriteRecord(Record);
            }
        }
    }
}
