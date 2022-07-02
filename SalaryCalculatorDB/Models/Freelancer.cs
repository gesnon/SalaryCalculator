using SalaryCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorDB.Models
{
    public class Freelancer: Person
    {
        public decimal HourSalary { get; }

        public Freelancer(string FullName)
        {
            this.FullName = FullName;
            HourSalary = 1000;

        }
    }
}
