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
    public class PersonService: IPersonService
    {
        private readonly DataService.IDataService<Record> recordService;
        private readonly DataService.IDataService<Person> personService;
        public PersonService()
        {
            this.personService = new CSVService<Person, PersonMaper>();
            this.recordService = new CSVService<Record, RecordMaper>();

        }
        public void CreateRecord(Record record)
        {
            string type = personService.ReadFromFile(@"C:\AllPersonal.csv").FirstOrDefault(_ => _.FullName == record.Owner).Type;
            List<Record> records = new List<Record>();
            records.Add(record);
            if (type == "Employee")
            {
                recordService.AddToFile(@"C:\EmployeesRecords.csv", records);
            }
            if (type == "Freelancer")
            {
                recordService.AddToFile(@"C:\FreelansersRecords.csv", records);
            }
        }

        public List<Record> GetPersonRecords(string name, DateTime firstDate, DateTime secondDate)
        {
            string type = personService.ReadFromFile(@"C:\AllPersonal.csv").FirstOrDefault(_ => _.FullName == name).Type;

            List<Record> records = new List<Record>();


            if (type == "Employee")
            {
                records = recordService.ReadFromFile(@"C:\EmployeesRecords.csv")
            .Where(_ => _.Date > firstDate && _.Date < secondDate && _.Owner == name).OrderBy(_ => _.Date).ToList();
            }
            if (type == "Freelancer")
            {
                records = recordService.ReadFromFile(@"C:\FreelansersRecords.csv")
            .Where(_ => _.Date > firstDate && _.Date < secondDate && _.Owner == name).OrderBy(_ => _.Date).ToList();
            }
            return records;
        }
    }
}
