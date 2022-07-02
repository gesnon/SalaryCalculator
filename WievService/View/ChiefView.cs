using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using SalaryCalculatorServices.Services.ChiefService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewService.View
{
    public class ChiefView : PersonView
    {
        ChiefService chiefService = new ChiefService();
        public void AddPerson()
        {
            Person person = new Person();

            Console.WriteLine("Добавление нового сотрудника ");

            Console.WriteLine("Введите имя");
            while (true)
            {
                string FullName = Console.ReadLine();

                if (chiefService.GetAllPerson().FirstOrDefault(_ => _.FullName == FullName) != null)
                {
                    Console.WriteLine("Сотрудник с таким именем уже существует, введите другое имя !");
                    continue;
                }

                if (FullName.All(Char.IsLetter)==false)
                {
                    Console.WriteLine("В имени должны быть только буквы !");
                    continue;
                }
                person.FullName = FullName;
                break;
            }

            Console.WriteLine("Выберите должность: 1 - Начальник, 2 - Сотрудник в штате, 3 - Внештатный сотрудник ");
            while (true)
            {
                int type = int.Parse(Console.ReadLine());

                if (type == 1 || type == 2 || type == 3)
                {
                    Console.WriteLine("Введите число от 1 до 3 ");

                    switch (type)
                    {
                        case 1:

                            chiefService.CreatePerson((Chief)person);
                            break;
                        case 2:
                            chiefService.CreatePerson((Employee)person);
                            break;
                        case 3:
                            chiefService.CreatePerson((Freelancer)person);
                            break;

                        default:
                            Console.WriteLine("Введите число от 1 до 3 ");
                            continue;
                    }

                }

            }

        }
    }
}
