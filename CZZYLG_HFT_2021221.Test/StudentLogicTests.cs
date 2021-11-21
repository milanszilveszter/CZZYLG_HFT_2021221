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
        IStudentLogic logic;

        [SetUp]
        public void Setup()
        {
            Mock<IStudentRepository> mockRepo = new Mock<IStudentRepository>();

            Teacher t1 = new Teacher() { TeacherId = 1, Name = "Teszt Tanár" , Age = 25};
            Teacher t2 = new Teacher() { TeacherId = 2, Name = "Teszt Tanár2", Age = 56 };

            mockRepo
                .Setup(x => x.ReadAll())
                .Returns(new List<Student>
                {
                    new Student()
                    {
                        Name = "Teszt1",
                        TeacherId = t1.TeacherId,
                        GradeAvg = 3.2f  
                    },
                    new Student()
                    {
                        Name = "Teszt2",
                        TeacherId = t2.TeacherId,
                        GradeAvg = 4f
                    },
                    new Student()
                    {
                        Name = "Teszt3",
                        TeacherId = t1.TeacherId,
                        GradeAvg = 2.6f
                    },
                    new Student()
                    {
                        Name = "Teszt4",
                        TeacherId = t2.TeacherId,
                        GradeAvg = 1.2f
                    },

                }.AsQueryable());

            logic = new StudentLogic(mockRepo.Object);
        }

        [Test]
        public void Test1()
        {
            double avg = logic.AllGradesAverage();

            Assert.That(avg, Is.EqualTo(2.75f));
        }

        [Test]
        public void Test2()
        {
        }
    }
}