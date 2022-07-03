using SalaryCalculator.Models;
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
            
            personView.GetLogInScreen();
            
            Person CurrentUser = systemService.LogIn();
            personView.GetGreetingsScreen(CurrentUser);
            switch (CurrentUser.Type)
            {
                case "Chief":
                ChiefView chiefView = new ChiefView();
                    
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
                                chiefView.AddTime();
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
