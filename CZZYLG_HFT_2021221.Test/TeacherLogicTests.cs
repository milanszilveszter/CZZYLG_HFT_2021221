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
    class TeacherLogicTests
    {
        ITeacherLogic itl;

        [SetUp]
        public void Setup()
        {
            Mock<ITeacherRepository> mockTeacherRepo = new Mock<ITeacherRepository>();

            Classroom cr1 = new Classroom()
            {
                Id = 1,
                ClassroomNumber = "AAA",
                Teachers = new List<Teacher>() { new Teacher() { Id = 1, Name = "Tanár1", Age = 51} },
                Students = new List<Student>()
            {
                new Student() { Id = 1, Name = "Diak1", Grade = 3.25, ClassroomId = 1 },
                new Student() { Id = 2, Name = "Diak2", Grade = 2.1, ClassroomId = 1 }
            }
            };
            Classroom cr2 = new Classroom()
            {
                Id = 2,
                ClassroomNumber = "BBB",
                Teachers = new List<Teacher>() { new Teacher() { Id = 2, Name = "Tanár2", Age = 60 } },
                Students = new List<Student>()
            {
                new Student() { Id = 3, Name = "Diak3", Grade = 3.5, ClassroomId = 2 },
                new Student() { Id = 4, Name = "Diak4", Grade = 5, ClassroomId = 2 },
                new Student() { Id = 5, Name = "Diak5", Grade = 4.3, ClassroomId = 2 },
            }
            };
            Classroom cr3 = new Classroom()
            {
                Id = 3,
                ClassroomNumber = "CCC",
                Teachers = new List<Teacher>() { new Teacher() { Id = 3, Name = "Tanár3", Age = 28 } },
                Students = new List<Student>()
            {
                new Student() { Id = 6, Name = "Diak6", Grade = 3, ClassroomId = 3 }
            }
            };
            Classroom cr4 = new Classroom()
            {
                Id = 4,
                ClassroomNumber = "DDD",
                Teachers = new List<Teacher>() { new Teacher() { Id = 4, Name = "Tanár4", Age = 44 } },
                Students = new List<Student>()
            {
                new Student() { Id = 7, Name = "Diak7", Grade = 1.2, ClassroomId = 4 },
                new Student() { Id = 8, Name = "Diak8", Grade = 4.4, ClassroomId = 4 }
            }
            };

            mockTeacherRepo.Setup(x => x.ReadAll())
                .Returns(new List<Teacher>
                {
                    new Teacher
                    {
                        Id = 1,
                        Name = "TEST TEACHER1",
                        Age = 41,
                        Subject = "sbj1",
                        ClassroomId = 1,
                        Classroom = cr1
                    },
                    new Teacher
                    {
                        Id = 2,
                        Name = "TEST TEACHER2",
                        Age = 12,
                        Subject = "sbj2",
                        ClassroomId = 2,
                        Classroom = cr2
                    },
                    new Teacher
                    {
                        Id = 3,
                        Name = "TEST TEACHER3",
                        Age = 21,
                        Subject = "sbj3",
                        ClassroomId = 3,
                        Classroom = cr3
                    },
                    new Teacher
                    {
                        Id = 4,
                        Name = "TEST TEACHER4",
                        Age = 64,
                        Subject = "sbj4",
                        ClassroomId = 4,
                        Classroom = cr4

                    },
                }.AsQueryable());

            itl = new TeacherLogic(mockTeacherRepo.Object);
        }

        [Test]
        public void AgeAvgTest()
        {
            double avg = itl.AgeAverage();

            Assert.That(avg, Is.EqualTo(34.5));
        }

        [Test] // CREATE
        public void CreateTest()
        {
            Assert.That(() => itl.Create(new Teacher { }), Throws.Exception);
        }

        [Test] // NON-CRUD
        public void WorstStudentsByTeachersTest()
        {
            var worstGrade = itl.WorstStudentsByTeachers().OrderByDescending(x => x.Key).First().Value.Grade;

            Assert.That(worstGrade, Is.EqualTo(1.2));
        }
    }
}
