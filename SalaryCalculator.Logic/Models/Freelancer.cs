using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Logic.Models
{
    public class Freelancer : BaseEmployee
    {
        public Freelancer(string firstName, string lastName) : base(firstName, lastName)
        {
            this.Salary = 1000;
            this.Type = "Freelancer";
        }

        public override void AddWorkTime(BaseEmployee baseEmployee, float workTime, DateTime workingDate, string comment)
        {
            var checkDate = (DateTime.Today - workingDate).Days;

            if (checkDate > 2)
            {
                throw new Exception("Поздно!");

            }

            base.AddWorkTime( this, workTime, workingDate, comment);

            return;
        }

    }
}
