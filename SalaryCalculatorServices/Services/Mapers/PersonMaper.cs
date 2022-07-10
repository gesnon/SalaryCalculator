using CsvHelper.Configuration;
using SalaryCalculator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.Mapers
{
    public class PersonMaper: ClassMap<Person>
    {
        public PersonMaper()
        {
            AutoMap(CultureInfo.InvariantCulture);
            
        }
    }
}
