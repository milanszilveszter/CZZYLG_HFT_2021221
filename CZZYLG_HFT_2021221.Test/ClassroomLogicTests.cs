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
    class ClassroomLogicTests
    {
        IClassRoomLogic icl;

        [SetUp]
        public void Setup()
        {
            Mock<IClassroomRepository> mockCourseRepo = new Mock<IClassroomRepository>();

            mockCourseRepo.Setup(x => x.ReadAll())
                .Returns(new List<Classroom>
                {
                    new Classroom
                    {
                        ClassroomNumber = "111",
                        TeacherId = 1
                    },
                    new Classroom
                    {
                        ClassroomNumber = "222",
                        TeacherId = 2
                    },
                    new Classroom
                    {
                        ClassroomNumber = "333",
                        TeacherId = 3
                    },
                    new Classroom
                    {
                        ClassroomNumber = "444",
                        TeacherId = 4
                    },
                }.AsQueryable()); 

            icl = new ClassRoomLogic(mockCourseRepo.Object);
        }

        [Test]
        public void Test1()
        {
            int count = icl.ClassroomCount();

            Assert.That(count, Is.EqualTo(4));
        }

        [Test]
        public void CreateTest()
        {
            Assert.That(() => icl.Create(new Classroom { }), Throws.Exception);
        }   
    }
}
