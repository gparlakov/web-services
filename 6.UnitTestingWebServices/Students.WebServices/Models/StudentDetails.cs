using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.WebServices.Controllers
{
    public class StudentDetails : StudentModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Grade { get; set; }

        public float AverageMark { get; set; }

        public float[] Marks { get; set; }
    }
}
