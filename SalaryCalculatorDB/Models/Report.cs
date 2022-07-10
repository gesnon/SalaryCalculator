using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorDB.Models
{
    public class Report
    {
        public int workingTime { get; set; }
        public decimal money { get; set; }
        public Report()
        {

        }
        public Report(int workingTime, decimal money)
        {
            this.workingTime = workingTime;
            this.money = money;
        }
    }
}
