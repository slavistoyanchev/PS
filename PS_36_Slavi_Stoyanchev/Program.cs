using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    class Program
    {
        public static  void ErrorHandling(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }
        public static void AddminMenu()
        {
            Console.WriteLine("Select an option");
            Console.WriteLine("0:Exit");
            Console.WriteLine("1:Changing the role of the user");
            Console.WriteLine("2:Change user activity");
            Console.WriteLine("3:User list");
            Console.WriteLine("4:View log file");
            Console.WriteLine("5:View current activity");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 0:
                    break;
                case 1:
                    String sName = Console.ReadLine();
                    int newRole = Convert.ToInt32(Console.ReadLine());
                    UserData.AssignUserRole(sName, (UserRoles)newRole);
                    break;
                case 2:
                    String sName2 = Console.ReadLine();
                    Console.WriteLine("Enter a date: ");
                    DateTime userDateTime;
                    if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
                    {
                        Console.WriteLine("The day of the week is: " + userDateTime.DayOfWeek);
                    }
                    else
                    {
                        Console.WriteLine("You have entered an incorrect value.");
                    }
                    UserData.SetUserActiveTo(sName2, userDateTime);
                    break;
                case 4:
                    IEnumerable<string> logLines = Logger.PrintLogFile();
                    foreach(string line in logLines)
                    {
                        Console.WriteLine(line);
                    }
                    break;
                case 5:
                   // Logger.GetCurrentSessionActivities();
                    StringBuilder sb = new StringBuilder();
                    string filter = "";
                    Console.WriteLine("Enter a fiter.");
                    filter = Console.ReadLine();
                    IEnumerable<string> currentActs = Logger.GetCurrentSessionActivities(filter);
                    foreach (String a in currentActs)
                    {
                        sb.Append(a);
                        sb.Append("\n");
                    }
                    Console.WriteLine(sb.ToString());
                    break;
                default:
                    break;
            }
        }
        public static void UserMenu()
        {
            Console.WriteLine("Select an option");
            Console.WriteLine("0:Exit");
            Console.WriteLine("1:Changing the role of the user");
            Console.WriteLine("2:Change user activity");
            //Console.WriteLine("3:View log file");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 0:
                    break;
                case 1:
                    String sName = Console.ReadLine();
                    int newRole = Convert.ToInt32(Console.ReadLine());
                    UserData.AssignUserRole(sName, (UserRoles)newRole);
                    break;
                case 2:
                    String sName2 = Console.ReadLine();
                    Console.WriteLine("Enter a date: ");
                    DateTime userDateTime;
                    if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
                    {
                        Console.WriteLine("The day of the week is: " + userDateTime.DayOfWeek);
                    }
                    else
                    {
                        Console.WriteLine("You have entered an incorrect value.");
                    }
                    UserData.SetUserActiveTo(sName2, userDateTime);
                    break;
                //case 3:
                //    Logger.PrintLogFile();
                //    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
         
            Console.WriteLine("Enter name: ");
            String  inputName = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            String inputPassword = Console.ReadLine();

            LoginValidation login = new LoginValidation(inputName, inputPassword, ErrorHandling);

            User user2=null;
            if (login.ValidateUserInput(ref user2))
            {
               
                Console.WriteLine(user2.name);
                Console.WriteLine(user2.password);
                Console.WriteLine(user2.FNumber);
                
                
                Console.WriteLine(LoginValidation.currentUserRole);

                
                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("ANONYMOUS");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("admin");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("inspector");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("professor");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("student");
                        break;
                    default:
                        Console.WriteLine("wrong role");
                        break;
                }
                if (user2.role == 1)
                {
                    AddminMenu();
                }
                else
                    UserMenu();
            }

        }
    }
}
