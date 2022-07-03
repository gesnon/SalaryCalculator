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
        public Person LogIn()
        {FillData data = new FillData();
            string name;
            List<Person> FileWithPersons = data.FillPersons();

            while (true)
            {
                string checkName = Console.ReadLine();
                if (CheckNameValid(checkName) == true)
                {
                    name = checkName;
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректное имя");
                    continue;
                }
            }

            Person? person = FileWithPersons.FirstOrDefault(_ => _.FullName == name);
            if (person == null)
            {                
                throw new Exception("Такого пользователя не существует");
            }
            switch (person.Type)
            {
                case "Chief":
                    return (Chief)person;
                case "Employee":
                    return (Employee)person;
                case "Freelancer":
                    return (Freelancer)person;
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
