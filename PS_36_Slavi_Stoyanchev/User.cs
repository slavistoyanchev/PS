using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
   public class User
    {

        public String name{ get; set; }
        public String password { get; set; }
        public String FNumber { get; set; }
        public Int32 role { get; set; }

        public DateTime Created { get; set; }

        public DateTime ValidTo { get; set; }

        public System.String Username
        {
            get;
            set;
        }
        public System.String PasswordTest
        {
            get;
            set;
        }
        public System.String FakNum
        {
            get;
            set;
        }
        public System.Int32 RoleTest
        {
            get; set;
        }
        public System.DateTime createdTest
        {
            get;
            set;
        }
        public System.DateTime ActiveTo
        {
            get; set;
        }

        public System.Int32 UserId { get; set; }
    }
}
