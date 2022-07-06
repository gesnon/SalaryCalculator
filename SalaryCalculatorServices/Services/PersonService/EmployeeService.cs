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
    public class EmployeeService : IPersonService
    {
        private readonly DataService.IDataService<Person> personService;
        private readonly DataService.IDataService<Record> recordService;
        public EmployeeService()
        {
            this.personService = new CSVService<Person, PersonMaper>();
            this.recordService = new CSVService<Record, RecordMaper>();
        }

        public void CreateRecord(Record record)
        {
            Person person = personService.ReadFromFile(@"C:\AllPersonal.csv").FirstOrDefault(_ => _.FullName == record.Creator.FullName);

            List<Record> records = new List<Record>();
            records.Add(record);
            recordService.AddToFile(@"C:\EmployeesRecords.csv", records);
        }

        public List<Record> GetPersonRecords(Person person,DateTime firstDate, DateTime secondDate)
        {
            List<Record> records = recordService.ReadFromFile(@"C:\EmployeesRecords.csv")
            .Where(_ => _.Date > firstDate && _.Date < secondDate && _.Owner.FullName == person.FullName).OrderBy(_ => _.Date).ToList();

            return records;
        }
    }
}
