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
    class CourseLogicTests
    {
        ICourseLogic icl;

        [SetUp]
        public void Setup()
        {
            Mock<ICourseRepository> mockCourseRepo = new Mock<ICourseRepository>();

            mockCourseRepo.Setup(x => x.ReadAll())
                .Returns(new List<Course>
                {
                    new Course
                    {
                        CourseId = 1,
                        CourseName = "hft",
                        TeacherId = 1
                    },
                    new Course
                    {
                        CourseId = 2,
                        CourseName = "villany",
                        TeacherId = 2
                    },
                    new Course
                    {
                        CourseId = 3,
                        CourseName = "dimat",
                        TeacherId = 3
                    },
                    new Course
                    {
                        CourseId = 4,
                        CourseName = "adatb",
                        TeacherId = 4
                    },
                }.AsQueryable()); 

            icl = new CourseLogic(mockCourseRepo.Object);
        }

        [Test]
        public void Test1()
        {
            int count = icl.CoursesCount();

            Assert.That(count, Is.EqualTo(4));
        }

        [Test]
        public void Test2()
        {
            Assert.That(() => icl.Create(new Course { CourseId = -1 }), Throws.Exception);
        }
    }
}
