using System.Collections.Generic;

namespace Students.Models
{
    public class School
    {
        private ICollection<Student> students;

        public School()
        {
            this.students = new List<Student>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return students; }
            set { students = value; }
        }
        
    }
}
