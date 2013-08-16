using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Students.Repository
{
    public interface IRepository<T>
    {
       T Add(T element);

       IQueryable<T> All();

       T Get(int id);

       //T Edit(int id, T element);

       //bool Delete(int id);

       //IQueryable<T> Find(Expression<Func<T, int, bool>> predicate);
    }
}
