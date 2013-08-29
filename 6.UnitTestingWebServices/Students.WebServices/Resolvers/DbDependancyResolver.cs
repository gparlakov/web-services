using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Students.Repository;
using Students.WebServices.Controllers;

namespace Students.WebServices.Resolvers
{
    public class DbDependancyResolver : IDependencyResolver 
    {
        private readonly DbStudentsContextFactory dbContexFactory;

        public DbDependancyResolver()
        {
            this.dbContexFactory = new Students.Repository.DbStudentsContextFactory();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(
                    new StudentsInSqlRepository(this.dbContexFactory));
            }
            else if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(new SchoolsInSqlRepository());
            }
            else 
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}