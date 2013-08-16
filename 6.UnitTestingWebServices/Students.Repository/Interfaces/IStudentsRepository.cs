using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repository
{
    public interface IStudentsRepository : IRepository<Student>
    {
        // in here we can add or remove methods
        // for instance :

        // IQueryable<Student> FindTopStudents(int count);

        // or implement a virtual method to not implement it below?

    //    Student Edit(int id, Student element)
    //    {
    //        return element;
    //    }
    }
}
