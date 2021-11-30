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

            Teacher t1 = new Teacher() { Id = 1, Name = "Tanar1", Age = 41, ClassroomId = 1};
            Teacher t2 = new Teacher() { Id = 2, Name = "Tanar2", Age = 24, ClassroomId = 2 };
            Teacher t3 = new Teacher() { Id = 3, Name = "Tanar3", Age = 51, ClassroomId = 3 };
            Teacher t4 = new Teacher() { Id = 4, Name = "Tanar4", Age = 67, ClassroomId = 4 };

            mockCourseRepo.Setup(x => x.ReadAll())
                .Returns(new List<Classroom>
                {
                    new Classroom
                    {
                        Id = 1,
                        ClassroomNumber = "111",
                        Teacher = t1
                    },
                    new Classroom
                    {
                        Id = 2,
                        ClassroomNumber = "222",
                        Teacher = t2
                    },
                    new Classroom
                    {
                        Id = 3,
                        ClassroomNumber = "333",
                        Teacher = t3
                    },
                    new Classroom
                    {
                        Id = 4,
                        ClassroomNumber = "444",
                        Teacher = t4
                    }
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
