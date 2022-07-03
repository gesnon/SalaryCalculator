using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using SalaryCalculatorServices.Services.DataService;
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
        }
        FillData dataBase = new FillData();
        private readonly DataService.IDataService<Person> personService;
        private readonly DataService.IDataService<Record> recordService;

        public ChiefService(IDataService<Person> personService, IDataService<Record> recordService)
        {
            this.personService = personService;
            this.recordService = recordService;

        }
        public void CreatePerson(Person person)
        {
            personService.Add(person);
        }

        public void CreateRecord(Person person, DateTime date, float time, string description)
        {
            
            Record record = new Record() { Date = date, Time = time, Description = description, Owner=person };
            recordService.Add(record);
        }

        public List<Record> GetAllPersonsRecords(DateTime firstDate, DateTime secondDate)
        {
            List<Record> records = new List<Record>();

            if (secondDate > DateTime.Now)
            {
                secondDate = DateTime.Now;
            }
            if (firstDate > DateTime.Now || firstDate > secondDate)
            {
                throw new Exception("Выбрано некорректное начало периода");
            }

            return records.Where(_ => _.Date > firstDate && _.Date < secondDate).OrderBy(_ => _.Date).ToList();
        }

        public List<Person> GetAllPerson()
        {
            return dataBase.FillPersons();
        }

        public Person GetPersonByName()
        {
            
            while (true)
            {
                string name = Console.ReadLine();
                if (name.All(Char.IsLetter) == false)
                {
                    Console.WriteLine("Имя должно состоять только из букв");
                    continue;
                }
                Person person = dataBase.FillPersons().FirstOrDefault(_ => _.FullName == name);
                if (person == null)
                {
                    Console.WriteLine("Сотрудник не найден!");
                    continue;
                }
                return person;
            }           
        }
        public List<Record> GetPersonRecords(Person person, DateTime firstDate, DateTime secondDate)
        {
            List<Record> records = new List<Record>();

            if (secondDate > DateTime.Now)
            {
                secondDate = DateTime.Now;
            }
            if (firstDate > DateTime.Now || firstDate > secondDate)
            {
                throw new Exception("Выбрано некорректное начало периода");
            }

            return records.Where(_ => _.Date > firstDate && _.Date < secondDate).OrderBy(_ => _.Date).ToList();
        }
    }
}
