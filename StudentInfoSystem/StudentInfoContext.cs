using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using UserLogin;

namespace StudentInfoSystem
{
    internal class StudentInfoContext : DbContext
    {
        public StudentInfoContext() : base(Properties.Settings.Default.DbConnect) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        public bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();

            IEnumerable<Student> queryStudents = context.Students;

            int countStudents = queryStudents.Count();

            if(countStudents == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CopyTestStudents()
        {
            if (TestStudentsIfEmpty())
            {

                StudentInfoContext context = new StudentInfoContext();

                foreach (Student st in StudentData.TestStudents)
                {
                    context.Students.Add(st);
                }

                context.SaveChanges();

            }
        }

    }    
}
