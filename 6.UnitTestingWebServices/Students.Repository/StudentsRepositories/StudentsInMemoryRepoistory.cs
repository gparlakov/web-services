using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Students.Repository
{
    public class StudentsInMemoryRepository : IRepository<Student>
    {
        private HashSet<Student> students;

        public StudentsInMemoryRepository()
        {
            this.students = new HashSet<Student>();
        }

        public Student Add(Student element)
        {
            this.students.Add(element);
            element.Id = students.Count;
            return element;
        }

        public IQueryable<Student> All()
        {
            return this.students.AsQueryable();
        }

        public Student Get(int id)
        {
            var found = this.students.FirstOrDefault(s => s.Id == id);

            return found;
        }

        public Student Edit(int id, Student element)
        {
            var found = this.Get(id);
            if (found == null)
            {
                throw new InvalidOperationException(
                    string.Format("No user with id {0} found", id));
            }

            this.students.Remove(found);
            element.Id = id;
            this.students.Add(element);            

            return element;
        }

        public bool Delete(int id)
        {
            var deleted = false;

            var found = this.Get(id);
            if (found == null)
            {
                throw new InvalidOperationException(
                    string.Format("No user with id {0} found", id));
            }

            return deleted;
        }

        public IQueryable<Student> Find(Expression<Func<Student, int, bool>> predicate)
        {
            var found = this.All().Where(predicate);

            return found;
        }
    }
}
