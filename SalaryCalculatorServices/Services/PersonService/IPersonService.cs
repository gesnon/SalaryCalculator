using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.PersonService
{
    public interface IPersonService
    {
        public void CreateRecord(Record record);
        public List<Record> GetPersonRecords(Person person, DateTime firstDate, DateTime secondDate);
               
    }
}
