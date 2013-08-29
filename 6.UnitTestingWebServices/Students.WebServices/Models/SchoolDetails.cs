using System;
using System.Collections.Generic;
using System.Linq;

namespace Students.WebServices.Models
{
    public class SchoolDetails : SchoolModel
    {
        public string Location { get; set; }

        public List<StudentModel> Students { get; set; }
    }
}