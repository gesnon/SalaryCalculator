using SalaryCalculator.Logic.ReadFile;
using SalaryCalculator.Logic.SaveFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaryCalculator.Logic.Models
{
    public class Journal
    {
        public List<TimeRecord> TimeJournal { get; set; }

        public List<TimeRecord> GetAllrecordsBetweenDate(DateTime firstDate,DateTime SecondDate)
        {
            List<TimeRecord> timeRecords = new List<TimeRecord>();

            ReadingFile readFile = new ReadingFile();

            timeRecords.AddRange(readFile.ReadFromFile<TimeRecord>(Settings1.Default.PathToEmployeeJournal));
            timeRecords.AddRange(readFile.ReadFromFile<TimeRecord>(Settings1.Default.PathToFreelancerJournal));
            timeRecords.AddRange(readFile.ReadFromFile<TimeRecord>(Settings1.Default.PathToHeadJournal));

            timeRecords=timeRecords.Where(q => q.WorkingDate >= firstDate && q.WorkingDate <= SecondDate).OrderBy(q => q.WorkingDate).ToList();

            return timeRecords;
        }

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
