using CsvHelper.Configuration;
using SalaryCalculatorDB.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.Mapers
{
    public class RecordMaper: ClassMap<Record>
    {
        public RecordMaper()
        {
            AutoMap(CultureInfo.InvariantCulture);
            
        }
    }
}
