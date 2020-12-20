using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Logic.Models
{
    public class Employee: BaseEmployee
    {   
        public Employee(string firstName, string lastName) :base (firstName, lastName) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = 750;
            this.Bonus = 1500;
            this.Type = "Employee";
        }

        public override void AddWorkTime( BaseEmployee baseEmployee, float workTime, DateTime workingDate, string comment)
        {
            base.AddWorkTime(this, workTime, workingDate, comment);
        }

        public override List<TimeRecord> GetPersonalTimeRecords(BaseEmployee baseEmployee, DateTime firstDate, DateTime lastDate, Journal timeJournal)
        {
            return base.GetPersonalTimeRecords(this, firstDate, lastDate, timeJournal);
        }

    }
}
