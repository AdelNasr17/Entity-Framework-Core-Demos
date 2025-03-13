using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_01_EFCore.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public virtual ICollection<StudentCourses> StudentCourses { get; set; }=new HashSet<StudentCourses>();

        //   public ICollection<Course> Courses { get; set; }= new HashSet<Course>();
    }
}
