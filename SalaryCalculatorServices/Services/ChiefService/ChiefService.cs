using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using SalaryCalculatorServices.Services.DataService;
using SalaryCalculatorServices.Services.Mapers;
using SalaryCalculatorServices.Services.SystemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.ChiefService
{
    public class ChiefService : IChiefService
    {
        public ChiefService()
        {
            this.personService = new CSVService<Person, PersonMaper>();
            this.recordService = new CSVService<Record, RecordMaper>();
        }

        private readonly DataService.IDataService<Person> personService;
        private readonly DataService.IDataService<Record> recordService;

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
        }   // Работает

        public void CreateRecord(Record record)
        {
            Person person = GetPersonByName(record.Owner.FullName);
            string path = " ";
            switch (person.Type)
            {
                case "Chief":
                    path = @"C:\ChiefsRecords.csv";
                    break;
                case "Employee":
                    path = @"C:\EmployeesRecords.csv";
                    break;
                case "Freelancer":
                    path = @"C:\FreelansersRecords.csv";
                    break;
            }
            List<Record> records = new List<Record>();
            records.Add(record);
            recordService.AddToFile(path, records);
        } // Работает

        public List<Record> GetAllPersonsRecords(DateTime firstDate, DateTime secondDate)
        {
            List<Record> ChiefsRecords = recordService.ReadFromFile(@"C:\ChiefsRecords.csv")
                .Where(_ => _.Date > firstDate && _.Date < secondDate).OrderBy(_ => _.Date).ToList();
            List<Record> EmployeesRecords = recordService.ReadFromFile(@"C:\EmployeesRecords.csv")
                .Where(_ => _.Date > firstDate && _.Date < secondDate).OrderBy(_ => _.Date).ToList();
            List<Record> FreelansersRecords = recordService.ReadFromFile(@"C:\FreelansersRecords.csv")
                .Where(_ => _.Date > firstDate && _.Date < secondDate).OrderBy(_ => _.Date).ToList();

            List<Record> exist = new List<Record>();
            if (ChiefsRecords != null)
            {
                exist.AddRange(ChiefsRecords);
            }
            if (EmployeesRecords != null)
            {
                exist.AddRange(EmployeesRecords);
            }
            if (FreelansersRecords != null)
            {
                exist.AddRange(FreelansersRecords);
            }

            return exist;
        }

        public List<Person> GetAllPerson()
        {
            return personService.ReadFromFile(@"C:\AllPersonal.csv");
        }

        public Person GetPersonByName(string name)
        {
            return GetAllPerson().FirstOrDefault(_ => _.FullName == name);

        }
        public List<Record> GetPersonRecords(Person person, DateTime firstDate, DateTime secondDate)
        {
            List<Record> records = new List<Record>();
            string path;
            if (person.Type == "Employee")
            {
                records = recordService.ReadFromFile(@"C:\EmployeesRecords.csv")
                    .Where(_ => _.Date > firstDate && _.Date < secondDate).OrderBy(_ => _.Date).ToList();
            };
            if (person.Type == "Chief")
            {
                records = recordService.ReadFromFile(@"C:\ChiefsRecords.csv")
                .Where(_ => _.Date > firstDate && _.Date < secondDate).OrderBy(_ => _.Date).ToList();
            };
            if (person.Type == "Freelancer")
            {
                records = recordService.ReadFromFile(@"C:\FreelansersRecords.csv")
                    .Where(_ => _.Date > firstDate && _.Date < secondDate).OrderBy(_ => _.Date).ToList();
            };

            return records;
        }
    }
}
