using SalaryCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorServices.Services.SystemService
{
    public interface ISystemService
    {
        public Person LogIn(string Name);
        public bool CheckNameValid(string Name);

        public DateTime CheckDateValid();
    }
}
