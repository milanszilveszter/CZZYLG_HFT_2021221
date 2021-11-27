
using CZZYLG_HFT_2021221.Logic;
using CZZYLG_HFT_2021221.Models;
using CZZYLG_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Test
{
    [TestFixture]
    class AllLogicTests
    {
        IStudentLogic isl;
        ICourseLogic icl;
        ITeacherLogic itl;

        [SetUp]
        public void Setup()
        {
            Mock<IStudentRepository> mockStudentRepo = new Mock<IStudentRepository>();
            Mock<ICourseRepository> mockCourseRepo = new Mock<ICourseRepository>();
            Mock<ITeacherRepository> mockTeacherRepo = new Mock<ITeacherRepository>();

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
                            new StudentCourses() { StudentId = 1, CourseId = 1 },
                            new StudentCourses() { StudentId = 1, CourseId = 2 }
                        }
                    },
                    new Student()
                    {
                        Name = "Teszt2",
                        Grade = 4,
                        StudentCourses = new List<StudentCourses>()
                        {
                            new StudentCourses() { StudentId = 2, CourseId = 1 },
                            new StudentCourses() { StudentId = 2, CourseId = 2 },
                            new StudentCourses() { StudentId = 2, CourseId = 3 }
                        }
                    },
                    new Student()
                    {
                        Name = "Teszt3",
                        Grade = 2.6,
                        StudentCourses = new List<StudentCourses>()
                        {
                            new StudentCourses() { StudentId = 3, CourseId = 2 }
                        }
                    },
                    new Student()
                    {
                        Name = "Teszt4",
                        Grade = 1.2,
                        StudentCourses = new List<StudentCourses>()
                        {
                            new StudentCourses() { StudentId = 4, CourseId = 2 },
                            new StudentCourses() { StudentId = 4, CourseId = 3 }
                        }
                    },

                }.AsQueryable());

            mockCourseRepo.Setup(x => x.ReadAll())
                .Returns(new List<Course>
                {
                    new Course
                    {
                        CourseId = 1,
                        CourseName = "hft",
                        TeacherId = 1,
                        StudentCourses = new List<StudentCourses>()
                        {
                            new StudentCourses() { StudentId = 1 },
                            new StudentCourses() { StudentId = 2 },
                        }
                    },
                    new Course
                    {
                        CourseId = 2,
                        CourseName = "villany",
                        TeacherId = 2,
                        StudentCourses = new List<StudentCourses>()
                        {
                            new StudentCourses() { StudentId = 1 },
                            new StudentCourses() { StudentId = 2 },
                        }
                    },
                    new Course
                    {
                        CourseId = 3,
                        CourseName = "dimat",
                        TeacherId = 3,
                        StudentCourses = new List<StudentCourses>()
                        {
                            new StudentCourses() { StudentId = 1 },
                            new StudentCourses() { StudentId = 2 },
                        }
                    },
                    new Course
                    {
                        CourseId = 4,
                        CourseName = "adatb",
                        TeacherId = 4,
                        StudentCourses = new List<StudentCourses>()
                        {
                            new StudentCourses() { StudentId = 1 },
                            new StudentCourses() { StudentId = 2 },
                        }
                    },
                }.AsQueryable());

            mockTeacherRepo.Setup(x => x.ReadAll())
                .Returns(new List<Teacher>
                {
                    new Teacher
                    {
                        TeacherId = 1,
                        Name = "TEST TEACHER1",
                        Age = 41
                    },
                    new Teacher
                    {
                        TeacherId = 2,
                        Name = "TEST TEACHER2",
                        Age = 12
                    },
                    new Teacher
                    {
                        TeacherId = 3,
                        Name = "TEST TEACHER3",
                        Age = 21
                    },
                    new Teacher
                    {
                        TeacherId = 4,
                        Name = "TEST TEACHER4",
                        Age = 64
                    },
                }.AsQueryable());


            isl = new StudentLogic(mockStudentRepo.Object);
            icl = new CourseLogic(mockCourseRepo.Object);
            itl = new TeacherLogic(mockTeacherRepo.Object);
        }
    }
}
