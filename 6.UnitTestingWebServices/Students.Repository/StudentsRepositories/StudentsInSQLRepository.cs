using Students.Models;
using System;
using System.Linq;

namespace Students.Repository
{
    public class StudentsInSqlRepository : IStudentsRepository
    {
        private const int MinNameLenght = 2;
        private const int MaxNameLenght = 50;
        private const int MaxGradeInSchool = 12;
        private const int MinGradeInSchool = 1;

        private readonly DbStudentsContextFactory dbContextFactory;

        public StudentsInSqlRepository(DbStudentsContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public Student Add(Student element)
        {
            ValidateStudentModel(element);

            var dbContext = this.dbContextFactory.Create();
            
            GetOrCreateSchool(element, dbContext);
            
            var addedElement = dbContext.Students.Add(element);
            dbContext.SaveChanges();

            return addedElement;
        }
        
        public IQueryable<Student> All()
        {
            var dbContext = this.dbContextFactory.Create();

            return dbContext.Students;
        }

        public Student Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id can not be non-positive");
            }

            var dbContext = this.dbContextFactory.Create();

            return dbContext.Students.FirstOrDefault(s => s.Id == id);
        }

        private void GetOrCreateSchool(Student student, Data.StudentsDb dbContext)
        {
            var schoolInRepository = dbContext.Schools.FirstOrDefault(s => s.Name == student.School.Name);

            if (schoolInRepository != null)
            {
                student.School = schoolInRepository;
                return;
            }

            dbContext.Schools.Add(student.School);
            dbContext.SaveChanges();
        }

        #region Not needed methods
        // not needed
        //public Models.Student Edit(int id, Models.Student element)
        //{
        //    var dbContext = this.dbContextFactory.Create();

        //    dbContext.Students.Attach(element);
        //    dbContext.SaveChanges();

        //    return element;
        //}

        //public bool Delete(int id)
        //{
        //    var dbContext = this.dbContextFactory.Create();

        //    var found = dbContext.Students.FirstOrDefault(s => s.Id == id);

        //    var deleted = false;
        //    if (found != null)
        //    {
        //        dbContext.Students.Remove(found);
        //        deleted = true;
        //    }

        //    return deleted;
        //}

        //public IQueryable<Student> Find(Expression<Func<Student, int, bool>> predicate)
        //{
        //    var found = this.All().Where(predicate);

        //    return found;
        //} 
        #endregion

        #region Validate student model
        private void ValidateStudentModel(Student element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Student","Student can't be null!");
            }

            ValidateName(element);
            ValidateSchool(element.School);
            ValidateGrade(element.Grade);
        }

        private void ValidateGrade(int grade)
        {
            if (grade < MinGradeInSchool || grade > MaxGradeInSchool)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Students grade must be between {0} and {1}",
                    MinGradeInSchool, MaxGradeInSchool));
            }
        }

        private void ValidateSchool(School school)
        {
            if (school == null)
            {
                throw new ArgumentNullException("School.","A student must have a school!");
            }
            if (school.Name == null)
            {
                throw new ArgumentNullException("SchoolName","A student' school must have a name!");
            }
        }

        private void ValidateName(Student element)
        {
            if (element.FirstName == null || element.LastName == null)
            {
                throw new ArgumentNullException("First name and Last name","A student must have First and Last name");
            }

            if (element.FirstName.Length < MinNameLenght ||
                element.LastName.Length < MinNameLenght)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Students names must be at least {0} symbols long", MinNameLenght));
            }

            if (element.FirstName.Length > MaxNameLenght ||
                element.LastName.Length > MaxNameLenght)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Students names must be at most {0} symbols long", MaxNameLenght));
            }
        }
        #endregion
    }
}
