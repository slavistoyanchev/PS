using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserLogin
{
    static public class UserData
    {
        static public List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return userTest;
            }
            set { }
        }
        private static List<User> userTest;

        public static void SetUserActiveTo(String name, DateTime newValid)
        {
            foreach (User use in TestUsers)
            {
                if (String.Equals(name, use.name))
                {
                    use.ValidTo = newValid;
                }
            }
            Logger.LogActivity("Промяна на активност на " + name);
        }
        public static void AssignUserRole(String name, UserRoles NewRole)
        {
            foreach (User use in TestUsers)
            {
                if (String.Equals(name, use.name))
                {
                    // use.role = ((int)NewRole);

                    UserContext context =

new UserContext();

                    int userid = 0;
                    User usr =
                    (from u in UserData.TestUsers
                     where u.UserId == userid
                     select u).First();
                    int newRole = 0;
                    usr.role = newRole;
                    context.SaveChanges();
                }
            }
            Logger.LogActivity("Промяна на роля на " + name);
        }
        static private void ResetTestUserData()
        {

            if (userTest == null)
            {

                userTest = new List<User>();
                userTest.Add(new User());
                userTest[0].name = "Slavi";
                userTest[0].password = "777499666";
                userTest[0].FNumber = "501219055";
                userTest[0].role = 4;
                userTest[0].Created = DateTime.Today;
                userTest[0].ValidTo = DateTime.MaxValue;

               
                userTest.Add(new User());
                userTest[1].name = "Slavi12";
                userTest[1].password = "1234a121";
                userTest[1].FNumber = "50121955";
                userTest[1].role = 1;
                userTest[1].Created = DateTime.Today;
                userTest[1].ValidTo = DateTime.MaxValue;


                
                userTest.Add(new User());
                userTest[2].name = "Ivan1";
                userTest[2].password = "123456";
                userTest[2].FNumber = "50121855";
                userTest[2].role = 1;
                userTest[2].Created = DateTime.Today;
                userTest[2].ValidTo = DateTime.MaxValue;

            }
        }
        static public User IsUserPassCorrect(String name, String pass)
        {

            User found = (from t in userTest
                          where t.name.Equals(name) && t.password.Equals(pass)
                          select t).First();
            return found;
        }

    }

}
