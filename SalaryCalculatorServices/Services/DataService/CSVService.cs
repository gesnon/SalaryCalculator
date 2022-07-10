using SalaryCalculatorDB.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculatorServices.Services.Mapers;

namespace SalaryCalculatorServices.Services.DataService
{
    public class CSVService<T, T1> : IDataService<T> where T1 : ClassMap
    {
        List<Record> exist = new List<Record>();
        public CSVService()
        {
            exist = new List<Record>();
        }
        public List<T> ReadFromFile(string path)
        {

            try
            {
                using (var writer = new StreamReader(path, Encoding.UTF8))
                {
                    var csvConfig = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-Ru"))
                    {
                        Delimiter = ","
                        
                    };
                    using (var csv = new CsvReader(writer, csvConfig))
                    {
                        var record = new Record();                        
                        csv.Context.RegisterClassMap<T1>();                        
                        var records = csv.GetRecords<T>().ToList();                        
                        return records;
                    }
                }

            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public void WriteToFile(string path, List<T> list)
        {
            using (var writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-Ru"))
                {
                    
                    Delimiter = ","
                };
                using (var csv = new CsvWriter(writer, csvConfig))
                {
                    csv.WriteHeader<T>();
                    csv.WriteRecords(list);
                }
            }
        }

        public void AddToFile(string path, List<T> records)
        {
    
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Don't write the header again.
                HasHeaderRecord = ReadFromFile(path).Count == 0                
            };
            using (var stream = File.Open(path, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                
                csv.WriteRecords(records);
            }
        }
    }


}

