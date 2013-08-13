using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repository
{
    public class SqlRepository<T> : IRepository<T> where T: class
    {
        private DbContext context;

        public SqlRepository()
        {
            this.context = new DbContext("StudentsDb");
        }

        public SqlRepository(DbContext context)
        {
            this.context = context;
        }

        public T Add(T element)
        {
            this.context.Set<T>().Add(element);
            this.context.SaveChanges();

            return element;
        }

        public IQueryable<T> All()
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            var entity = this.context.Set<T>().Find(id);
            return entity;
        }

        public T Edit(int id, T element)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
