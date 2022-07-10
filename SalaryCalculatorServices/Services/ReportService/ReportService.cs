using SalaryCalculatorDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.ReportService
{
    public class ReportService
    {
        ChiefService.ChiefService chiefService = new ChiefService.ChiefService();
        public Report GetPersonReport(List<Record> records)
        {
            Report report = new Report();

            foreach (Record record in records)
            {
                string typeOfPerson = chiefService.GetPersonByName(record.Owner).Type;
                report.workingTime += record.Time;
                if (typeOfPerson == "Employee")
                {
                    if (record.Time > 8)
                    {
                        report.money+=(record.Time-8)*120000/80+8*120000/160;
                        continue;
                    }
                    report.money+=record.Time*120000/160;                   
                }
                if (typeOfPerson == "Chief")
                {
                    report.money += record.Time * 200000 / 160;

                    if (record.Time > 8)
                    {
                        report.money += 1000;                       
                    }                  
                    
                }
                if (typeOfPerson == "Freelancer")
                {
                    report.money += record.Time * 1000;
                }
            }
            return report;
        }
    }
}
