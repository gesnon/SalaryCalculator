using SalaryCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorDB.Models
{
    public class Record
    {   
        public int ID { get; } // не используется
        public int Time { get; set; }
        public DateTime Date { get; set; }
        public string Owner { get; set; }
        public string Creator { get; set; }
        public string? Description { get; set; }

        public Record()
        {

        }
        public Record(int Time, DateTime Date, string Description, string Owner, string Creator)
        {
            this.Time = Time;
            this.Date = Date;
            this.Description = Description;
            this.Owner = Owner;
            this.Creator = Creator;
        }
    }
}
