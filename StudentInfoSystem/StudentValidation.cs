using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        public static Student GetStudentDataByUser(User obj)
        {
            Boolean emptyFacultyNumber;
            emptyFacultyNumber = obj.FNumber.Equals(String.Empty);
            if (emptyFacultyNumber == true)
            {
               
               Console.WriteLine( "Wrong faculty number");
                
                return null;
            }
            Student a = new Student();
            foreach(Student st in StudentData.TestStudents)
            {
                if (obj.FNumber.Equals(st.facultyNumber))
                {
                    return st;
                }
            }
            return null;
        }
    }
}
