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
                        TeacherId = 1,
                        GradeAvg = 3.2f
                    },
                    new Student()
                    {
                        Name = "Teszt2",
                        TeacherId = 2,
                        GradeAvg = 4f
                    },
                    new Student()
                    {
                        Name = "Teszt3",
                        TeacherId = 3,
                        GradeAvg = 2.6f
                    },
                    new Student()
                    {
                        Name = "Teszt4",
                        TeacherId = 4,
                        GradeAvg = 1.2f
                    },

                }.AsQueryable());

            isl = new StudentLogic(mockStudentRepo.Object);
        }

        [Test]
        public void Test1()
        {
            double avg = isl.AllGradesAverage();

            Assert.That(avg, Is.EqualTo(2.75f));
        }

        [Test]
        public void Test2()
        {        
            Assert.That(() => isl.Create(new Student { StudentId = -1 }), Throws.Exception);
        }
    }
}