using SalaryCalculator.Logic.SaveFile;
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

        public void CreateEmployee(string firstName, string lastName, EmployeeType employeeType)
        {
            BaseEmployee employee = null;

            SaveToFile saveToFile = new SaveToFile();          

            switch (employeeType)
            {
                case EmployeeType.Employee:
                    employee = new Employee(firstName, lastName);
                    break;

                case EmployeeType.Head:
                    employee = new Head(firstName, lastName);
                    break;
                case EmployeeType.Freelanser:
                    employee = new Freelancer(firstName, lastName);
                    break;
                default: throw new Exception("Ошибка!");
            }
            saveToFile.Save(Settings1.Default.PathToAllEmployees,employee);
        }

        public List<TimeRecord> GetTimeRecords(DateTime firstDate, DateTime lastDate, Journal timeJournal)
        {
            List<TimeRecord> Journal = timeJournal.TimeJournal.Where(q => q.WorkingDate >= firstDate && q.WorkingDate <= lastDate).OrderBy(q => q.WorkingDate).ToList();
            return Journal;
        }


    }
}
