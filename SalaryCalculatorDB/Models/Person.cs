using SalaryCalculatorDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Models
{
    public class Person
    {
        public string FullName { get; set; }        
        public string Type { get; set; }
        public decimal Salary { get; set; }
        public decimal Bonus { get; set; }
        public List<Record> TimeRecords { get; set; } = new List<Record>(); //Возможно лучше просто хранить ID записей
    }
}
