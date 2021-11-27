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

            mockStudentRepo
                .Setup(x => x.ReadAll())
                .Returns(new List<Student>
                {
                    new Student()
                    {
                        Name = "Teszt1",
                        Grade = 3.2,
                        StudentCourses = new List<StudentCourses>()
                        {
                            new StudentCourses() { CourseId = 1 },
                            new StudentCourses() { CourseId = 2 }
                        }
                    },
                    new Student()
                    {
                        Name = "Teszt2",
                        Grade = 4,
                        StudentCourses = new List<StudentCourses>()
                        {
                            new StudentCourses() { CourseId = 1 },
                            new StudentCourses() { CourseId = 2 },
                            new StudentCourses() { CourseId = 3 }
                        }
                    },
                    new Student()
                    {
                        Name = "Teszt3",
                        Grade = 2.6,
                        StudentCourses = new List<StudentCourses>()
                        {
                            new StudentCourses() { CourseId = 2 }
                        }
                    },
                    new Student()
                    {
                        Name = "Teszt4",
                        Grade = 1.2,
                        StudentCourses = new List<StudentCourses>()
                        {
                            new StudentCourses() { CourseId = 2 },
                            new StudentCourses() { CourseId = 3 }
                        }
                    },

                }.AsQueryable());

            isl = new StudentLogic(mockStudentRepo.Object);
        }

        [Test]
        public void Test1()
        {
            Assert.That(isl.AllGradesAverage(), Is.EqualTo(2.75f));
        }

        [Test]
        public void CoursesCountTest()
        {
            Assert.That(isl.CoursesCount(), Is.EqualTo(8));
        }

        [Test]
        public void CreateTest()
        {
            Assert.That(() => isl.Create(new Student { }), Throws.Exception);
        }

        [Test]
        public void StudentsByCourseTest()
        {
            Assert.That(isl.StudentsByCourse(2).Count(), Is.EqualTo(4));
        }

        [Test]
        public void StudentGradeAvgByCourseTest()
        {
            Assert.That(isl.StudentGradeAvgByCourse(1), Is.EqualTo(3.6));
        }
    }
}