using CsvHelper;
using SalaryCalculator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SalaryCalculator.Logic.SaveFile
{
    public class SaveHeadjournal
    {
        public List<TimeRecord> timeRecords { get; set; }

        public SaveHeadjournal (List<TimeRecord> timeRecords)
        {
            this.timeRecords = timeRecords;
        }
        public void Save()
        {
            using (var writer = new StreamWriter(@"C:\Programs\MVS2019\Microsoft Visual Studio\SaveFile\HeadJournal.csv", false, Encoding.Unicode))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<MyConfigForHeadJournal>();

                csv.WriteRecords(timeRecords);
            }
        }
    }
}
