using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Logic.Models
{
    public class TimeRecord
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Time { get; set; }
        public DateTime DateOfRecord { get; set; } = DateTime.Now;
        public DateTime WorkingDate { get; set; }
        public string Comment { get; set; }

    }
}
