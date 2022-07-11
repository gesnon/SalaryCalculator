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
        public Person LogIn(string name)
        {           
            
            Person person = chiefService.GetPersonByName(name);

            if (person == null)
            {
                return null;
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
            return Name.All(c => char.IsLetter(c) || c == ' '||c=='-');
            
        }
        public DateTime CheckDateValid()
        {
            DateTime dob;
            string input;
            do
            {                
                input = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out dob));

            return dob;
        }

        public int CheckTimeValid()
        {
            decimal time;
            string input;
            while (true)
            {                
                input = Console.ReadLine();
                if (Decimal.TryParse(input, out time))
                {                    
                    return (int)time;
                }
                
                else { Console.WriteLine("Вы должны ввести число "); }
                continue;
            }            

        }

        public string getPath(string name)
        {
            string path = @"C:\ChiefsRecords.csv";
            string type = chiefService.GetPersonByName(name).Type;
            if (type == "Employee")
            {
                path = @"C:\EmployeesRecords.csv";
            }
            if (type == "Freelancer")
            {
                path = @"C:\FreelansersRecords.csv";
            }
            return path;
        }
    }
}
