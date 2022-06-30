using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using SalaryCalculatorServices.Services.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.ChiefService
{
    public class ChiefService : IChiefService
    {
        private readonly DataService.IDataService<Person> personService;
        private readonly DataService.IDataService<Record> recordService;
        public ChiefService(IDataService<Person> personService, IDataService<Record> recordService)
        {
            this.personService = personService;
            this.recordService = recordService;
        }
        public void CreatePerson()
        {
            personService.Add(new Person { });
        }

        public void CreateRecord()
        {
            Record record = new Record() { Date = DateTime.Now, Time = 8.0f, Description = "New Description" };
            recordService.Add(record);
        }

        public List<Record> GetAllPersonsRecords()
        {
            List<Record> records = new List<Record>();

            return records;
        }

        public List<Person> GetAllPerson()
        {
            return new List<Person>();
        }

        public Person GetPersonById(int ID)
        {
            Person person = personService.Get().FirstOrDefault(_=>_.ID==ID);
            if (person == null)
            {
                throw new Exception("Не найден");
            }
            return person;
        }
        public List<Record> GetPersonRecords(Person person)
        {
            List<Record> records = new List<Record>();

            return records;
        }
    }
}
