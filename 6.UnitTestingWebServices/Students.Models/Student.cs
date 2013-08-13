using System.Collections.Generic;

namespace Students.Models
{
    public class Student
    {
        private ICollection<Mark> marks;

        public Student()
        {
            this.marks = new List<Mark>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }

        public virtual ICollection<Mark> Marks
        {
            get { return marks; }
            set { marks = value; }
        }

        public virtual School School { get; set; }
    }
}
