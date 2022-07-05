using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.ChiefService
{
    public interface IChiefService
    {
        public void AddPerson(Person person);
        public void CreateRecord(Person person, DateTime date, float time, string description);
        public List<Record> GetAllPersonsRecords(DateTime firstDate, DateTime secondDate);
        public List<Record> GetPersonRecords(Person person, DateTime firstDate, DateTime secondDate);
        public List<Person> GetAllPerson();
        public Person GetPersonByName();
               
    }
}
