using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using SalaryCalculatorServices.Services.ChiefService;
using SalaryCalculatorServices.Services.SystemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewService.View
{
    public class ChiefView : PersonView
    {
        ChiefService chiefService = new ChiefService();
        SystemService systemService = new SystemService();

        public void ChiefFunctions()
        {
            Console.WriteLine("1. Добавить сотрудника");
            Console.WriteLine("2. Просмотреть отчет по всем сотрудникам");
            Console.WriteLine("3.Просмотреть отчет по конкретному сотруднику");
            Console.WriteLine("4. Добавить часы работы");
            Console.WriteLine("5. Выход из программы");
        }
        public void AddPerson()
        {
            
            Person person = new Person();

            Console.WriteLine("Добавление нового сотрудника ");

            Console.WriteLine("Введите имя");
            while (true)
            {
                string FullName = Console.ReadLine();

                if (chiefService.GetAllPerson().FirstOrDefault(_ => _.FullName == FullName) != null)
                {
                    Console.WriteLine("Сотрудник с таким именем уже существует, введите другое имя !");
                    continue;
                }

                if (systemService.CheckNameValid(FullName) == false)
                {
                    Console.WriteLine("В имени должны быть только буквы !");
                    continue;
                }
                person.FullName = FullName;                
                break;
            }

            Console.WriteLine("Выберите должность: 1 - Начальник, 2 - Сотрудник в штате, 3 - Внештатный сотрудник ");
            while (true)
            {
                int type = int.Parse(Console.ReadLine());

                switch (type)
                {
                    case 1:
                                                
                        chiefService.AddPerson(new Chief(person.FullName));
                        Console.WriteLine("Добавлен!");
                        break;
                    case 2:
                        chiefService.AddPerson(new Employee(person.FullName));
                        Console.WriteLine("Добавлен!");
                        break;
                    case 3:
                        chiefService.AddPerson(new Freelancer(person.FullName));
                        Console.WriteLine("Добавлен!");
                        break;

                    default:
                        Console.WriteLine("Дефолт Введите число от 1 до 3 ");
                        continue;
                }
                break;

            }

        }

        public void GetAllPersonsView()
        {
            List<Person> persons = chiefService.GetAllPerson();
            foreach (Person person in persons)
            {
                Console.WriteLine(person.FullName + ", " + person.Type);
            }

        }

        public void GetAllPersonsRecords()
        {
            Console.WriteLine("Введите налало и конец периода в формате dd.mm.yyyy:");
            Console.WriteLine("Начало периода: ");
            DateTime firstDate = systemService.CheckDateValid();
            Console.WriteLine("Окончание периода: ");
            DateTime secondDate = systemService.CheckDateValid();
            List<Record> records = chiefService.GetAllPersonsRecords(firstDate, secondDate);
            foreach (Record record in records)
            {
                Console.WriteLine(record.Date + ", " + record.Owner + ", " + record.Time + ", " + record.Description);
            }
        }
        public void GetPersonRecords()
        {
            Console.WriteLine("Введите имя работника:");
            Person person = chiefService.GetPersonByName();
            Console.WriteLine("Введите налало и конец периода в формате dd.mm.yyyy:");
            Console.WriteLine("Начало периода: ");
            DateTime firstDate = systemService.CheckDateValid();
            Console.WriteLine("Окончание периода: ");

                
            DateTime secondDate = systemService.CheckDateValid();
            List<Record> records = chiefService.GetAllPersonsRecords(firstDate, secondDate);
            foreach (Record record in records)
            {
                Console.WriteLine(record.Date + ", " + record.Owner + ", " + record.Time + ", " + record.Description);
            }
        }

        public void AddTime()
        {
            Console.WriteLine("Введите имя работника:");
            Person person = chiefService.GetPersonByName();
            Console.WriteLine("Введите дату: ");
            DateTime date = systemService.CheckDateValid();
            Console.WriteLine("Введите время: ");
            float time = systemService.CheckTimeValid();
            Console.WriteLine("Введите описание: ");
            string description = Console.ReadLine();
            chiefService.CreateRecord(person, date, time, description);
        }
    }
}
