using System.Collections.Generic;
using System.Linq;

namespace Students.Repository
{
    public interface IRepository<T>
    {
       T Add(T element);

       IQueryable<T> All();

       T Get(int id);

       T Edit(int id, T element);

       bool Delete(int id);
    }
}
