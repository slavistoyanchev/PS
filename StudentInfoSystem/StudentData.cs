using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class StudentData
    {
        static public List<Student> TestStudents { get; private set; }

       public StudentData()
        {
            TestStudents = new List<Student>();
            TestStudents.Add(new Student());
            TestStudents[0].name = "Slavi";
            TestStudents[0].faculty = "FKST";
            TestStudents[0].specialty = "ITI";
            TestStudents[0].degree = "bachelor";
            TestStudents[0].status = "certified";
            TestStudents[0].facultyNumber = "501219055" ;
            TestStudents[0].course = "3";
            TestStudents[0].stream = "2";
            TestStudents[0].group = "36";
        }

        public List<Student> GetTestStudents()
        {
            return TestStudents;
        }

        public Student IsThereStudent()
        {
            StudentInfoContext context = new StudentInfoContext();

            string facNum = null;
            Student result =
            (from st in context.Students where st.facultyNumber == facNum select st).First();
            return result;
        }
    }

}
