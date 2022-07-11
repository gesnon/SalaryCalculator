using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using SalaryCalculatorServices.Services.DataService;
using SalaryCalculatorServices.Services.Mapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly DataService.IDataService<Record> recordService;
        private readonly DataService.IDataService<Person> personService;
        private readonly SystemService.ISystemService systemService;
        public PersonService()
        {
            this.personService = new CSVService<Person, PersonMaper>();
            this.recordService = new CSVService<Record, RecordMaper>();

        }
        public List<Person> GetAllPerson()
        {
            return personService.ReadFromFile(@"C:\AllPersonal.csv");
        }

        public Person GetPersonByName(string name)
        {
            return GetAllPerson().FirstOrDefault(_ => _.FullName == name);

        }
        public void CreateRecord(Record record)
        {
            Person person = GetPersonByName(record.Owner);
            string path = systemService.getPath(person.FullName);
            List<Record> records = new List<Record>();
            records.Add(record);
            recordService.AddToFile(path, records);
        }

        public List<Record> GetPersonRecords(Person person, DateTime firstDate, DateTime secondDate)
        {
            List<Record> records = new List<Record>();
            string name = person.FullName;
            string path = systemService.getPath(name);
            
            records = recordService.ReadFromFile(path)
            .Where(_ => _.Date > firstDate && _.Date < secondDate && _.Owner == name).OrderBy(_ => _.Date).ToList();
            return records;
        }
    }
}
