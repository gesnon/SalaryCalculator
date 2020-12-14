using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaryCalculator.Logic.Models
{
    public class Head : BaseEmployee
    {
        public Head(string firstName, string lastName) : base(firstName, lastName)
        {
            this.Salary = 1250;
            this.Bonus = 20000;
            this.Type = "Head";
        }

        public BaseEmployee CreateEmployee(string firstName, string lastName, EmployeeType employeeType)
        {
            switch (employeeType)
            {
                case EmployeeType.Employee: return new BaseEmployee(firstName, lastName);

                case EmployeeType.Head: return new Head(firstName, lastName);

                case EmployeeType.Freelanser: return new Freelancer(firstName, lastName);

                default: throw new Exception("Ошибка!");
            }
        }             

        public List<TimeRecord> GetTimeRecords(DateTime firstDate, DateTime lastDate, Journal timeJournal)
        {
            List<TimeRecord> Journal = timeJournal.TimeJournal.Where(q => q.WorkingDate >= firstDate && q.WorkingDate <= lastDate).OrderBy(q => q.WorkingDate).ToList();
            return Journal;
        }


    }
}
