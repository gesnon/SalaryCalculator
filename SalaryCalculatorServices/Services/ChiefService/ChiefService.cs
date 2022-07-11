using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using SalaryCalculatorServices.Services.DataService;
using SalaryCalculatorServices.Services.Mapers;
using SalaryCalculatorServices.Services.PersonService;
using SalaryCalculatorServices.Services.SystemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.ChiefService
{
    public class ChiefService : PersonService.PersonService
    {
        
        public ChiefService()
        {
            this.personService = new CSVService<Person, PersonMaper>();
            this.recordService = new CSVService<Record, RecordMaper>();
        }

        private readonly DataService.IDataService<Person> personService;
        private readonly DataService.IDataService<Record> recordService;
        private readonly SystemService.ISystemService systemService;
        public ChiefService(IDataService<Person> personService, IDataService<Record> recordService)
        {
            this.personService = personService;
            this.recordService = recordService;

        }
        public void AddPerson(Person person)
        {
            List<Person> persons = new List<Person>();
            persons.Add(person);
            personService.AddToFile(@"C:\AllPersonal.csv", persons);
        }   

        public List<Record> GetAllPersonsRecords(DateTime firstDate, DateTime secondDate)
        {
            var pathsToCheck = new string[]
                { @"C:\ChiefsRecords.csv", @"C:\EmployeesRecords.csv", @"C:\FreelansersRecords.csv" };
            List<Record> records = new List<Record>();
            foreach (var path in pathsToCheck)
            {
                records.AddRange(GetPersonsRecords(firstDate, secondDate, path));
            }

            return records;
        }

        private List<Record> GetPersonsRecords(DateTime firstDate, DateTime secondDate, string path)
        {
            List<Record> ChiefsRecords = recordService.ReadFromFile(path)
                .Where(_=>_.Date > firstDate &&_.Date < secondDate).OrderBy(_=>_.Date).ToList();
            return ChiefsRecords;
        }


    }
}
