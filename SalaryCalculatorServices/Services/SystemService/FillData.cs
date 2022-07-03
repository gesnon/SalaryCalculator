using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.SystemService
{
    public class FillData
    {

        public FillData()
        {

        }
        public List<Person> FillPersons()
        {

            return new List<Person>()
                {
                new Employee("ИванИванов"),
                new Employee("МаксимПетров"),
                new Employee("ПетрИванов"),
                new Freelancer("ВладИванов"),
                new Freelancer("КоляИванов"),
                new Freelancer("СергейИванов"),
                new Chief("ВикторИванов"),
                new Chief("ВадимИванов")
                };

        }


    }
}
