using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.SystemService
{
    public class SystemService : ISystemService
    {
        ChiefService.ChiefService chiefService = new ChiefService.ChiefService();
        public Person LogIn()
        {
            
            string name;
            Person person;
            List<Person> FileWithPersons = chiefService.GetAllPerson();

            while (true)
            {
                string checkName = Console.ReadLine();
                if (CheckNameValid(checkName) == false)
                {
                    Console.WriteLine("Некорректное имя");
                    continue;                    
                }
                person = FileWithPersons.FirstOrDefault(_ => _.FullName == checkName);
                if (person== null)
                {
                    Console.WriteLine("Такого пользователя не существует ");
                    continue;
                }
                break;
            }
                      

            switch (person.Type)
            {
                case "Chief":
                    return new Chief(person.FullName);
                case "Employee":
                    return new Employee(person.FullName);
                case "Freelancer":
                    return new Freelancer(person.FullName);
                    default: throw new Exception("Какое-то исключение");
            }
        }
        public bool CheckNameValid(string Name)
        {
            if (Name.All(Char.IsLetter) == false)
            {                
                return false;
            }            
            return true;
        }
        public DateTime CheckDateValid()
        {
            DateTime dob;
            string input;
            do
            {
                Console.WriteLine("Введите дату в формате дд.ММ.гггг (день.месяц.год):");
                input = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out dob));

            return dob;
        }

        public float CheckTimeValid()
        {
            double time;
            string input;
            while (true)
            {                
                input = Console.ReadLine();
                if (Double.TryParse(input, out time))
                {                    
                    return (float)time;
                }
                
                else { Console.WriteLine("Вы должны ввести число "); }
                continue;
            }

            

        }
    }
}
