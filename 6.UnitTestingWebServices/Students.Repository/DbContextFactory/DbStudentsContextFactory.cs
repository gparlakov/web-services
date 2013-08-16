using Students.Data;
using System.Data.Entity.Infrastructure;

namespace Students.Repository
{
    public class DbStudentsContextFactory: IDbContextFactory<StudentsDb>
    {
        public StudentsDb Create()
        {
           return new StudentsDb();
        }
    }
}
