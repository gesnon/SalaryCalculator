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
    public class PersonView
    {
        SystemService systemService = new SystemService();
        PersonService personService = new PersonService();
        public PersonView()
        {

        }
        public void PersonFunctions()
        {
            Console.WriteLine("1. Просмотреть отчет за период");
            Console.WriteLine("2. Добавить часы работы");
            Console.WriteLine("3. Выход из программы");
        }
        public void GetLogInScreen()
        {
            Console.WriteLine("Введите ваше имя");

        }
        public Person LogIn()
        {
            string name;
            Person person;
            while (true)
            {
                name = Console.ReadLine();

                if (systemService.CheckNameValid(name) == false)
                {
                    Console.WriteLine("Имя должно состоять только из букв");
                    continue;
                }

                person = systemService.LogIn(name);
                if (person == null)
                {
                    Console.WriteLine("Пользолватель не найден");
                    continue;
                }
                break;
            }

            return person;
        }
        public void GetGreetingsScreen(Person person)
        {
            Console.WriteLine("Здравствуйте, " + person.FullName);
            Console.WriteLine("Ваша роль, " + person.Type);
            Console.WriteLine("Выберите Желаемое действие:");
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

            List<Record> records = personService.GetPersonRecords(person.FullName, firstDate, secondDate);


            foreach (Record record in records)
            {
                Console.WriteLine(record.Date + ", " + record.Time + ", " + record.Description);
            }
        }
    }
}
