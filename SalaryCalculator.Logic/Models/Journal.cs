using SalaryCalculator.Logic.SaveFile;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Logic.Models
{
    public class Journal
    {
        public List<TimeRecord> TimeJournal { get; set; }

        private string GetPath (BaseEmployee baseEmployee)
        {
            if (baseEmployee is Employee)
            {
                return Settings1.Default.PathToEmployeeJournal;
            }
            if (baseEmployee is Head)
            {
                return Settings1.Default.PathToHeadJournal;
            }
            if (baseEmployee is Freelancer)
            {
                return Settings1.Default.PathToFreelancerJournal;
            }

            throw new Exception("Не найден путь к файлу");
        }

        public void AddWorkTime(BaseEmployee baseEmployee, float workTime, DateTime workingDate, string comment)
        {        

            TimeRecord timeRecord = new TimeRecord
            {
                FirstName = baseEmployee.FirstName,
                LastName = baseEmployee.LastName,
                Time = workTime,
                WorkingDate = workingDate,
                DateOfRecord = DateTime.Today,
                Comment = comment
            };

            SaveToFile saveTime = new SaveFile.SaveToFile();

            saveTime.Save(GetPath(baseEmployee), timeRecord);
        }
    }
}
