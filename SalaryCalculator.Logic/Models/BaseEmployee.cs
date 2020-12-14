using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaryCalculator.Logic.Models
{
    public class BaseEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public decimal Bonus { get; set; }
        public string Type { get; set; }

        public BaseEmployee(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual void AddWorkTime(Journal timeJournal, BaseEmployee baseEmployee, float workTime, DateTime workingDate, string comment)
        {
            timeJournal.TimeJournal.Add(new TimeRecord
            {
                FirstName = baseEmployee.FirstName,
                LastName = baseEmployee.LastName,
                Time = workTime,
                WorkingDate = workingDate,
                DateOfRecord = DateTime.Today,
                Comment = comment
            });
        }

        public virtual List<TimeRecord> GetPersonalTimeRecords(BaseEmployee baseEmployee, DateTime firstDate, DateTime lastDate, Journal timeJournal)
        {
            List<TimeRecord> Journal = timeJournal.TimeJournal.Where(q => q.WorkingDate >= firstDate
                                                                          && q.WorkingDate <= lastDate
                                                                          && q.FirstName == baseEmployee.FirstName
                                                                          && q.LastName == baseEmployee.LastName).OrderBy(q => q.WorkingDate).ToList();
            return Journal;
        }

        public virtual decimal GetSalary(BaseEmployee baseEmployee, DateTime firstDate, DateTime lastDate, Journal timeJournal)
        {
            List<TimeRecord> ListRecordForSalary = GetPersonalTimeRecords(baseEmployee, firstDate, lastDate, timeJournal);

            decimal Salary=0;

            foreach(TimeRecord Record in ListRecordForSalary)
            {
                Salary = Salary + (decimal)Record.Time * baseEmployee.Salary;
            }

            return Salary;
        }

    }
}
