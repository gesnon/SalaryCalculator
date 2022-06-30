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
        public void CreatePerson();
        public void CreateRecord();
        public List<Record> GetAllPersonsRecords();
        public List<Record> GetPersonRecords(Person person);
        public List<Person> GetAllPerson();
        public Person GetPersonById(int id);
               
    }
}
