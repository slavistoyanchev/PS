using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public String name = "";
        public String surname = "";
        public String familyName = "";
        public String faculty = "";
        public String specialty = "";
        public String degree = "";
        public String status = "";
        public String facultyNumber = "";
        public String course = "";
        public String stream = "";
        public String group = "";

        public string Name { get; set; }
        public string Surname { get; set; }
        public string FamilyName { get; set; }
        public byte[] Photo { get; set; }

        public int StudentId { get; set; }

        public bool isEmpty()
        {
            return name.Equals("") || surname.Equals("") || familyName.Equals("") || faculty.Equals("") || specialty.Equals("") ||
                degree.Equals("") || status.Equals("") || facultyNumber.Equals("") || course.Equals("") || stream.Equals("") || group.Equals("");
        }
    }
}
