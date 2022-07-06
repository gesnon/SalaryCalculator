using SalaryCalculator.Models;
using SalaryCalculatorServices.Services.SystemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewService.View
{
    public class PersonView
    {
        SystemService systemService = new SystemService();
        public PersonView()
        {

        }          
        public void GetLogInScreen()
        {
            Console.WriteLine("Введите ваше имя");

        }
        public Person LogIn()
        {
            string name;
            Person person;
            while (true)
            {
                name = Console.ReadLine();

                if (systemService.CheckNameValid(name)==false)
                {
                    Console.WriteLine("Имя должно состоять только из букв");
                    continue;
                }
                
                person = systemService.LogIn(name);
                if (person == null)
                {
                    Console.WriteLine("Пользолватель не найден");
                    continue ;
                }
                break;
            }            

            return person;
        }
        public void GetGreetingsScreen(Person person)
        {
            Console.WriteLine("Здравствуйте, " + person.FullName);
            Console.WriteLine("Ваша роль, " + person.Type);
            Console.WriteLine("Выберите Желаемое действие:");
        }
        
    }
}
