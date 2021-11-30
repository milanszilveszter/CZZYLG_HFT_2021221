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
    class TeacherLogicTests
    {
        ITeacherLogic itl;

        [SetUp]
        public void Setup()
        {
            Mock<ITeacherRepository> mockTeacherRepo = new Mock<ITeacherRepository>();

            mockTeacherRepo.Setup(x => x.ReadAll())
                .Returns(new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "TEST TEACHER1",
                        Age = 41,
                        Subject = "sbj1",
                    },
                    new Teacher
                    {
                        Name = "TEST TEACHER2",
                        Age = 12,
                        Subject = "sbj2"
                    },
                    new Teacher
                    {
                        Name = "TEST TEACHER3",
                        Age = 21,
                        Subject = "sbj3"
                    },
                    new Teacher
                    {
                        Name = "TEST TEACHER4",
                        Age = 64,
                        Subject = "sbj4"
                    },
                }.AsQueryable());

            itl = new TeacherLogic(mockTeacherRepo.Object);
        }

        [Test]
        public void Test1()
        {
            double avg = itl.AgeAverage();

            Assert.That(avg, Is.EqualTo(34.5));
        }

        [Test]
        public void CreateTest()
        {
            Assert.That(() => itl.Create(new Teacher { }), Throws.Exception);
        }
    }
}
