using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
   public class LoginValidation
    {
        static public String name { get; private set; }
        private String password { get; set; }
        private String error { get; set; }

        public static UserRoles currentUserRole { get; private set; }
        public delegate void ActionOnError(string errorMsg);
        private static  ActionOnError _errorfunc;
        public bool ValidateUserInput(ref User u)
        {

            Boolean emptyUserName;
            emptyUserName = name.Equals(String.Empty);

            if (emptyUserName == true)
            { 
                currentUserRole = UserRoles.ANONYMOUS;
                error = "No username specified";
                _errorfunc(error);
                return false;
            }
            Boolean emptyPassword;
            emptyPassword = password.Equals(String.Empty);
            if (emptyPassword == true)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                error = "No password specified";
                _errorfunc(error);
                return false;
            }
            if (name.Length < 5) 
            {
                currentUserRole = UserRoles.ANONYMOUS;
                error = "The name must not be less than 5 characters long.";
                _errorfunc(error);
                return false;
            }
            if (password.Length < 5)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                error = "The password must not be less than 5 characters long.";
                _errorfunc(error);
                return false;
            }
            User us = UserData.IsUserPassCorrect(name, password);
            if (us == null)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                error = "Invalid username or password.";
                _errorfunc(error);
                return false;
            }
            currentUserRole = (UserRoles)us.role;
            u = us;
            Logger.LogActivity("Успешен Login");
            return true;

        }
        
        public LoginValidation(String n, String pass, ActionOnError b)
        {
            name=n;
            password = pass;
            _errorfunc = b;
        }
    }
}
