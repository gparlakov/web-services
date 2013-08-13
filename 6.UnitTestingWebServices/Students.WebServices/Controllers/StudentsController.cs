using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Data;
using Students.Models;
using Students.Repository;

namespace Students.WebServices.Controllers
{
    public class StudentsController : ApiController
    {
        private IRepository<Student> studentsRepository;

        public StudentsController ()
	    {
            this.studentsRepository = 
                new Repository.SqlRepository<Student>(new StudentsDb());
	    }

        // GET api/values
        [Queryable]
        public IQueryable<StudentModel> Get()
        {
            var students = this.studentsRepository.All().Select(s => new StudentModel 
            {
                FullName = (s.FirstName ?? "student") + " " + s.LastName,
                Id = s.Id
            });

            return students;
        }

        // GET api/values/5
        public StudentDetails Get(int id)
        {
            var student = this.studentsRepository.Get(id);
            var marks = student.Marks.Select(m => m.Value).ToArray();

            var averageMark = GetAverageMark(marks);

            var studentDetails = new StudentDetails
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                FullName = (student.FirstName ?? "student") + " " + student.LastName,
                Grade = student.Grade,
                Marks = marks,
                AverageMark = averageMark
            };

            return studentDetails;
        }

        private static float GetAverageMark(float[] marks)
        {
            if (marks.Length == 0)
            {
                return 0f;
            }
            var sumOfMarks = marks.Sum();
            var countOfMarks = marks.Count();

            var averageMark = ((float)sumOfMarks) / countOfMarks;
            return averageMark;
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Student student)
        {
            //TODO - add modelstate checker or just student checker
            if (student.LastName != null)
            {
                this.studentsRepository.Add(student);

                var response = Request.CreateResponse(HttpStatusCode.Created, student);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id=student.Id} ));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "Model of student is not valid - LastName is Required");
            }
        }

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
