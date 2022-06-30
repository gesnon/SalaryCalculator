using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorDB.Models
{
    public class Employee: Person
    {
        public Employee(string FullName)
        {
            this.FullName = FullName;
            Salary = 120000;           

        }
    }
}
