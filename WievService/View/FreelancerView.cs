using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using SalaryCalculatorServices.Services.PersonService;
using SalaryCalculatorServices.Services.SystemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewService.View
{
    public class FreelancerView
    {
        FreelancerService freelancerService = new FreelancerService();
        SystemService systemService = new SystemService();
        public void FreelancerFunctions()
        {
            Console.WriteLine("1. Просмотреть отчет за период");
            Console.WriteLine("2. Добавить часы работы");
            Console.WriteLine("3. Выход из программы");
        }
        public void GetPersonRecords(Person person)
        {
            DateTime firstDate;
            DateTime secondDate;

            while (true)
            {
                Console.WriteLine("Введите налало и конец периода в формате дд.ММ.гггг (день.месяц.год):");
                Console.WriteLine("Начало периода: ");
                firstDate = systemService.CheckDateValid();
                Console.WriteLine("Окончание периода: ");
                secondDate = systemService.CheckDateValid();
                if (secondDate > DateTime.Now)
                {
                    secondDate = DateTime.Now;
                }
                if (firstDate > secondDate)
                {
                    Console.WriteLine("Некорректный период");
                    continue;
                }
                break;
            }

            List<Record> records = freelancerService.GetPersonRecords(person.FullName, firstDate, secondDate);
            foreach (Record record in records)
            {
                Console.WriteLine(record.Date + ", " + record.Time + ", " + record.Description);
            }
        }

        public void AddRecord(Person creator)
        {
            DateTime date;
            while (true)
            {
                Console.WriteLine("Введите дату: ");
                date = systemService.CheckDateValid();
                if (DateTime.Now.AddDays(-2)>date)
                {
                    Console.WriteLine("Слишком поздно !");
                    continue ;
                }
                break;
            }

            
            Console.WriteLine("Введите время: ");
            int time = systemService.CheckTimeValid();
            Console.WriteLine("Введите описание: ");
            string description = Console.ReadLine();
            freelancerService.CreateRecord(new Record() { Date = date, Time = time, Owner = creator.FullName, Creator = creator.FullName, Description = description });
        }
    }
}
