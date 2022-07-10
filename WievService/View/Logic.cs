using SalaryCalculator.Models;
using SalaryCalculatorDB.Models;
using SalaryCalculatorServices.Services.SystemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewService.View
{
    public class Logic
    {
        public Logic()
        {

        }        
        public void Start()
        {
            PersonView personView = new PersonView();
            SystemService systemService = new SystemService();
            ChiefView chiefView = new ChiefView();     
            EmployeeView employeeView = new EmployeeView();  
            FreelancerView freelancerView = new FreelancerView();
            personView.GetLogInScreen();
            Person CurrentUser = personView.LogIn();
            personView.GetGreetingsScreen(CurrentUser);
            //Chief CurrentUser = new Chief("Иван");
            switch (CurrentUser.Type)
            {
                case "Chief":                 
                    
                    while (true)
                    {
                        chiefView.ChiefFunctions();
                        int function = Convert.ToInt32(Console.ReadLine());
                        if (function == 5)
                        {
                            break;
                        }
                        switch (function)
                        {
                            case 1:
                                chiefView.AddPerson();
                                break;
                            case 2:

                                chiefView.GetAllPersonsRecords();
                                break;
                            case 3:
                                chiefView.GetPersonRecords();
                                break;
                            case 4:
                                chiefView.AddRecord(CurrentUser);
                                break;

                            default:
                                Console.WriteLine("Этот функционал Пока не реализован");
                                break;
                        }
                    }
                    break;

                case "Employee":
                    while (true)
                    {
                        employeeView.PersonFunctions();
                        int function = Convert.ToInt32(Console.ReadLine());
                        if (function == 3)
                        {
                            break;
                        }
                        switch (function)
                        {
                            case 1:
                                employeeView.GetPersonRecords(CurrentUser);
                                break;
                            case 2:
                                employeeView.AddRecord(CurrentUser);
                                break;

                            default:
                                Console.WriteLine("Этот функционал Пока не реализован");
                                break;
                        }
                    }
                    break;
                case "Freelancer":
                    while (true)
                    {
                        freelancerView.PersonFunctions();
                        int function = Convert.ToInt32(Console.ReadLine());
                        if (function == 3)
                        {
                            break;
                        }
                        switch (function)
                        {
                            case 1:
                                freelancerView.GetPersonRecords(CurrentUser);
                                break;
                            case 2:
                                freelancerView.AddRecord(CurrentUser);
                                break;

                            default:
                                Console.WriteLine("Этот функционал Пока не реализован");
                                break;
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Этот функционал Пока не реализован");
                    break;
            }

        }
        
    }
}
