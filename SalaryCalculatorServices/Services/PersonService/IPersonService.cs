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
        public void CreateRecord(float Time, string Description, DateTime Date, Person Owner, Person Creator);
        public List<Record> GetPersonRecords(Person person, Person getter);
               
    }
}
