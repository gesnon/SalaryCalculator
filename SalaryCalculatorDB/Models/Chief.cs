using SalaryCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorDB.Models
{
    public class Chief: Person
    {
        public Chief(string FullName)
        {
            this.FullName = FullName;
            Type = "Chief";
            Salary = 200000;
            Bonus = 20000;
        }
    }
}
