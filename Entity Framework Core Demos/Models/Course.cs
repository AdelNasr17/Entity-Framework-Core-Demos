using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_01_EFCore.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        //   public ICollection<Student> Students { get; set; }= new HashSet<Student>();

        public virtual ICollection<StudentCourses> CourseStudents { get; set; }= new HashSet<StudentCourses>();
    }
}
