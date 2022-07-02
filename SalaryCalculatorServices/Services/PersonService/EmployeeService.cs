using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using SalaryCalculatorServices.Services.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.PersonService
{
    public class EmployeeService : IPersonService
    {
        private readonly DataService.IDataService<Record> recordService;
        public EmployeeService( IDataService<Record> recordService)
        {
            this.recordService = recordService;
        }


        public void CreateRecord(float Time, string Description, DateTime Date, Person Owner, Person Creator)
        {
            if(Owner.ID != Creator.ID)
            {
                throw new Exception("Время можно добавлять только себе");
            }

            Record record = new Record() { Date = DateTime.Now, Time = 8.0f, Description = "New Description", Creator=Creator, Owner=Owner };
            recordService.Add(record);
        }

        public List<Record> GetPersonRecords(Person person, Person getter)
        {
            if (getter.ID != person.ID)
            {
                throw new Exception("Время можно просматривать только у себя");
            }

            List<Record> records = new List<Record>();

            return records;
        }
    }
}
