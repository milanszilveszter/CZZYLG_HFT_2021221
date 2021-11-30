using CZZYLG_HFT_2021221.Logic;
using CZZYLG_HFT_2021221.Models;
using CZZYLG_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CZZYLG_HFT_2021221.Test
{
    [TestFixture]
    class StudentLogicTests
    {
        IStudentLogic isl;

        [SetUp]
        public void Setup()
        {
            Mock<IStudentRepository> mockStudentRepo = new Mock<IStudentRepository>();

            Classroom cr1 = new Classroom() { Id = 1, ClassroomNumber = "AAA", Teacher = new Teacher() { Id = 1, Name = "Tanár1", Age = 51 } };
            Classroom cr2 = new Classroom() { Id = 2, ClassroomNumber = "BBB", Teacher = new Teacher() { Id = 2, Name = "Tanár2", Age = 60 } };
            Classroom cr3 = new Classroom() { Id = 3, ClassroomNumber = "CCC", Teacher = new Teacher() { Id = 3, Name = "Tanár3", Age = 28 } };
            Classroom cr4 = new Classroom() { Id = 4, ClassroomNumber = "DDD", Teacher = new Teacher() { Id = 4, Name = "Tanár4", Age = 44 } };

            mockStudentRepo
                .Setup(x => x.ReadAll())
                .Returns(new List<Student>
                {
                    new Student()
                    {
                        Id = 1,
                        Name = "Teszt1",
                        Grade = 3.2,
                        ClassroomId = cr1.Id,
                        Classroom = cr1
                    },
                    new Student()
                    {
                        Id = 2,
                        Name = "Teszt2",
                        Grade = 4,
                        ClassroomId = cr2.Id,
                        Classroom = cr2
                    },
                    new Student()
                    {
                        Id = 3,
                        Name = "Teszt3",
                        Grade = 2.6,
                        ClassroomId = cr3.Id,
                        Classroom = cr3
                    },
                    new Student()
                    {
                        Id = 4,
                        Name = "Teszt4",
                        Grade = 1.2,
                        ClassroomId = cr4.Id,
                        Classroom = cr4
                    },
                    new Student()
                    {
                        Id = 5,
                        Name = "Teszt5",
                        Grade = 3.6,
                        ClassroomId = cr1.Id,
                        Classroom = cr1
                    }

                }.AsQueryable()) ;

            isl = new StudentLogic(mockStudentRepo.Object);
        }

        [Test]
        public void AllGradesAverageTest()
        {
            Assert.That(isl.AllGradesAverage(), Is.EqualTo(2.92));
        }      

        [Test] // CREATE TEST
        public void CreateTest()
        {
            Assert.That(() => isl.Create(new Student { }), Throws.Exception);
        }

        [Test]
        public void StudentsInTheSameClassroomTest()
        {
            Assert.That(isl.StudentsInTheSameClassroom(1).Count(), Is.EqualTo(2));
        }

        [Test] // NON-CRUD
        public void StudentsWithOldTeachersTest()
        {
            Assert.That(isl.StudentsWithOldTeachers().Count(), Is.EqualTo(3));
        }
    }
}