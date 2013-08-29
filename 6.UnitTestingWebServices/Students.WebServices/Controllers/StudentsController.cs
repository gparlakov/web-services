using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Models;
using Students.Repository;
using Students.WebServices.Models;

namespace Students.WebServices.Controllers
{
    public class StudentsController : BaseApiController
    {
        private readonly IRepository<Student> studentsRepository;
        
        public StudentsController(IRepository<Student> studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        // GET api/students
        [Queryable]
        public IQueryable<StudentModel> Get()
        {
            return this.ProcessAndHandleExceptions(() =>
            {
                var students = this.studentsRepository.All().Select(s => new StudentModel
                {
                    FullName = (s.FirstName ?? "student") + " " + s.LastName,
                    Id = s.Id
                });

                return students;
            });
        }

        // GET api/students/5
        public StudentDetails Get(int id)
        {
            return this.ProcessAndHandleExceptions(() => 
            {
                var student = this.studentsRepository.Get(id);

                if (student == null)
                {
                    throw new InvalidOperationException(string.Format("No student with id = {0} found", id));
                }

                var studentDetails = new StudentDetails
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    FullName = string.Format("{0} {1}", student.FirstName ?? "student", student.LastName),
                    Grade = student.Grade,
                };

                return studentDetails;
            });
        }

        // GET api/students?subject=math&value=5.00
        public IQueryable<StudentModel> Get(string subject, float value)
        {
            return this.ProcessAndHandleExceptions(() =>
            {
                var allStudents = this.studentsRepository.All();
                var selectedStudents = allStudents
                    .Where(s => s.Marks.Any(m => m.Subject == subject && m.Value >= value))
                    .Select(s => new StudentModel
                    {
                        Id = s.Id,
                        FullName = s.FirstName + " " + s.LastName
                    });

                return selectedStudents;
            });
        }

        // POST api/values
        public HttpResponseMessage Post(Student student)
        {
            return this.ProcessAndHandleExceptions(() =>
            {
                student = this.studentsRepository.Add(student);

                var studentDetails = new StudentDetails
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    FullName = student.FirstName + " " + student.LastName,
                    Grade = student.Grade,
                };

                var response = this.Request.CreateResponse(HttpStatusCode.Created, studentDetails);
                response.Headers.Location = new Uri(this.Url.Link("DefaultApi", new { id = student.Id }));

                return response;
            });
        }
    }
}