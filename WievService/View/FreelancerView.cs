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
    public class FreelancerView: PersonView
    {
        PersonService personService = new PersonService();
        SystemService systemService = new SystemService();

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
            personService.CreateRecord(new Record() { Date = date, Time = time, Owner = creator.FullName, Creator = creator.FullName, Description = description });
        }
    }
}
