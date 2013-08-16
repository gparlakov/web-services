using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Students.Models;
using Students.Repository;

namespace Students.RepositoriesTests
{
    [TestClass]
    public class StudentsRepositoryInSqlTests
    {
        private const int MinNameLenght = 2;
        private const int MaxNameLenght = 50;
        private const int MaxGradeInSchool = 12;
        private const int MinGradeInSchool = 1;

        private static TransactionScope scope;

        [TestInitialize]
        public void TestInitialize()
        {
            scope = new TransactionScope();            
        }

        public void Destroy()
        {
            scope.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_StudentIsNull_ShouldThrowException()
        {
            Student testStudent = null;
            var repository = new StudentsInSQLRepository(new DbStudentsContextFactory());

            repository.Add(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_StudentSchoolIsNull_ShouldThrowException()
        {
            Student testStudent = new Student
            {
                School = null
            };

            var repository = new StudentsInSQLRepository(new DbStudentsContextFactory());

            repository.Add(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_StudentWithSchool_NameIsNull_ShouldThrowException()
        {
            Student testStudent = new Student
            {
                School = new School
                {                    
                }
            };

            var repository = new StudentsInSQLRepository(new DbStudentsContextFactory());

            repository.Add(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_StudentFirstNameIsNull_ShouldThrowException()
        {
            Student testStudent = new Student 
            {
                LastName = "Test Student Last Name",
                School = new School
                {
                    Name = "Telerik Academy"
                },
                Grade = 5
            };

            var repository = new StudentsInSQLRepository(new DbStudentsContextFactory());

            repository.Add(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_StudentLastNameIsNull_ShouldThrowException()
        {
            Student testStudent = new Student
            {
                FirstName = "Test Student Last Name",
                School = new School
                {
                    Name = "Telerik Academy"
                },
                Grade = 5
            };

            var repository = new StudentsInSQLRepository(new DbStudentsContextFactory());

            repository.Add(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_StudentFirstNameIsTooShort_ShouldThrowException()
        {
            Student testStudent = new Student
            {
                FirstName = "T",
                LastName = "Test Student Last Name",
                School = new School
                {
                    Name = "Telerik Academy"
                },
                Grade = 5
            };

            var repository = new StudentsInSQLRepository(new DbStudentsContextFactory());

            repository.Add(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_StudentFirstNameIsTooLong_ShouldThrowException()
        {
            Student testStudent = new Student
            {
                FirstName = new string('t', MaxNameLenght + 1),
                LastName = "Test Student Last Name",
                School = new School
                {
                    Name = "Telerik Academy"
                },
                Grade = 5
            };

            var repository = new StudentsInSQLRepository(new DbStudentsContextFactory());

            repository.Add(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_StudentLastNameIsTooShort_ShouldThrowException()
        {
            Student testStudent = new Student
            {
                LastName = "T",
                FirstName = "Test Student Last Name",
                School = new School
                {
                    Name = "Telerik Academy"
                },
                Grade = 5
            };

            var repository = new StudentsInSQLRepository(new DbStudentsContextFactory());

            repository.Add(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_StudentLastNameIsTooLong_ShouldThrowException()
        {
            Student testStudent = new Student
            {
                LastName = new string('t', MaxNameLenght + 1),
                FirstName = "Test Student Last Name",
                School = new School
                {
                    Name = "Telerik Academy"
                },
                Grade = 5
            };

            var repository = new StudentsInSQLRepository(new DbStudentsContextFactory());

            repository.Add(testStudent);
        }
    }
}
