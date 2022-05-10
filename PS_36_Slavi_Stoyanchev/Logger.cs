using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserLogin
{
   static public class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();
        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                + LoginValidation.name + ";"
                + LoginValidation.currentUserRole + ";"
                + activity + "\n";
            currentSessionActivities.Add(activityLine);

            if(File.Exists("log.txt") == true)
            {
                Console.WriteLine("loging.");
                File.AppendAllText("log.txt", activityLine);
            }
        }
        static public IEnumerable<string> PrintLogFile()
        {
            StreamReader sr = new StreamReader("log.txt");
            List<string> filelines = new List<string>();
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                line += "\n";
                filelines.Add(line);
            }
            sr.Close();
            return filelines ;
        }

        static public IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();

            return filteredActivities;
        }
    }
}
