﻿using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using SalaryCalculatorServices.Services.ChiefService;
using SalaryCalculatorServices.Services.PersonService;
using SalaryCalculatorServices.Services.SystemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewService.View
{
    public class EmployeeView: PersonView
    {
        PersonService personService=new PersonService();
        SystemService systemService = new SystemService();

       
        public void AddRecord(Person creator)
        {
            Console.WriteLine("Введите дату: ");
            DateTime date = systemService.CheckDateValid();
            Console.WriteLine("Введите время: ");
            int time = systemService.CheckTimeValid();
            Console.WriteLine("Введите описание: ");
            string description = Console.ReadLine();
            personService.CreateRecord(new Record() { Date = date, Time = time, Owner = creator.FullName, Creator = creator.FullName, Description = description });
        }
    }
}
