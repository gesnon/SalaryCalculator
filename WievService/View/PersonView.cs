using SalaryCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewService.View
{
    public class PersonView
    {
        public PersonView()
        {

        }          
        public void GetLogInScreen()
        {
            Console.WriteLine("Введите ваше имя");

        }
        public void GetGreetingsScreen(Person person)
        {
            Console.WriteLine("Здравствуйте, " + person.FullName);
            Console.WriteLine("Ваша роль, " + person.Type);
            Console.WriteLine("Выберите Желаемое действие:");
        }
    }
}
