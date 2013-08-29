using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Students.Models;
using Students.Repository;
using Students.WebServices.Models;

namespace Students.WebServices.Controllers
{
    public class SchoolsController : BaseApiController
    {
        private readonly IRepository<School> repository;

        public SchoolsController(IRepository<School> repository)
        {
            this.repository = repository;
        }

        // api/schools
        public HttpResponseMessage PostSchool(School school)
        {
            var message = this.ProcessAndHandleExceptions(() => 
            {
                var added = this.repository.Add(school);

                var response = this.Request.CreateResponse(HttpStatusCode.Created, added);
                var location = new Uri(this.Url.Link("DefaultApi", new{Id = added.Id}));
                response.Headers.Location = location;

                return response;
            });

            return message;
        }

        // api/schools        
        public IEnumerable<SchoolModel> GetSchools()
        {
            return this.ProcessAndHandleExceptions(() =>
            {
                var schools = this.repository.All()
                    .Select(s => new SchoolModel
                    {
                        Id = s.Id,
                        Name = s.Name
                    }).AsEnumerable();

                return schools;
            });
        }

        public SchoolDetails GetSchool(int id) 
        {
            return this.ProcessAndHandleExceptions(() => 
            {
                var school = this.repository.Get(id);
                var schoolDetails = new SchoolDetails {
                    Id = school.Id,
                    Name = school.Name,
                    Location =school.Location,
                    Students = school.Students.Select(s=>new StudentModel
                    {
                        Id = s.Id,
                        FullName = s.FirstName + " " + s.LastName
                    }).ToList()
                };

                return schoolDetails;
            });
        }
    }
}
