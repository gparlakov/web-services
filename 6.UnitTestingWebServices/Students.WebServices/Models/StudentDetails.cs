using System;
using System.Collections.Generic;
using System.Linq;

namespace Students.WebServices.Models
{
    public class StudentDetails : StudentModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Grade { get; set; }

        //public float AverageMark { get; set; }

        //public IEnumerable<MarkModel> Marks { get; set; }

        //public SchoolModel School { get; set; }
    }
}