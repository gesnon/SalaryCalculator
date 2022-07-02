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
        public int ID { get; }
        public float Time { get; set; }
        public DateTime Date { get; set; }
        public Person Owner { get; set; }
        public Person Creator { get; set; }
        public string? Description { get; set; }

        public Record()
        {

        }
        public Record(float Time, DateTime Date, string Description, Person Owner, Person Creator)
        {
            this.Time = Time;
            this.Date = Date;
            this.Description = Description;
            this.Owner = Owner;
            this.Creator = Creator;
        }
    }
}
