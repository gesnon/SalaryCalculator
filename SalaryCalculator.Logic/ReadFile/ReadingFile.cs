using CsvHelper;
using SalaryCalculator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace SalaryCalculator.Logic.ReadFile
{
    public class ReadingFile
    {
        public List<T> ReadFromFile<T>(string pathToFile)
        {
            using (var reader = new StreamReader(pathToFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<T>();

                return records.ToList();
            }

        }
    }
}
