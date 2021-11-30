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
        IClassroomLogic icl;

        [SetUp]
        public void Setup()
        {
            Mock<IClassroomRepository> mockCourseRepo = new Mock<IClassroomRepository>();

            Teacher t1 = new Teacher() { Id = 1, Name = "Tanar1", Age = 29, ClassroomId = 1};
            Teacher t2 = new Teacher() { Id = 2, Name = "Tanar2", Age = 24, ClassroomId = 2 };
            Teacher t3 = new Teacher() { Id = 3, Name = "Tanar3", Age = 51, ClassroomId = 3 };
            Teacher t4 = new Teacher() { Id = 4, Name = "Tanar4", Age = 67, ClassroomId = 4 };

            Student s1 = new Student() { Id = 1, Name = "Diak1", Grade = 3.5, ClassroomId = 1 };
            Student s2 = new Student() { Id = 2, Name = "Diak2", Grade = 2.1, ClassroomId = 2 };
            Student s3 = new Student() { Id = 3, Name = "Diak3", Grade = 4.2, ClassroomId = 2 };
            Student s4 = new Student() { Id = 4, Name = "Diak4", Grade = 5, ClassroomId = 3 };
            Student s5 = new Student() { Id = 5, Name = "Diak5", Grade = 1.6, ClassroomId = 3 };
            Student s6 = new Student() { Id = 6, Name = "Diak6", Grade = 2, ClassroomId = 3 };
            Student s7 = new Student() { Id = 7, Name = "Diak7", Grade = 3.2, ClassroomId = 4 };

            mockCourseRepo.Setup(x => x.ReadAll())
                .Returns(new List<Classroom>
                {
                    new Classroom
                    {
                        Id = 1,
                        ClassroomNumber = "111",
                        Teacher = t1,
                        Students = new List<Student>()
                        {
                            s1
                        }
                    },
                    new Classroom
                    {
                        Id = 2,
                        ClassroomNumber = "222",
                        Teacher = t2,
                        Students = new List<Student>()
                        {
                            s2, s3
                        }
                    },
                    new Classroom
                    {
                        Id = 3,
                        ClassroomNumber = "333",
                        Teacher = t3,
                        Students = new List<Student>()
                        {
                            s4, s5, s6
                        }
                    },
                    new Classroom
                    {
                        Id = 4,
                        ClassroomNumber = "444",
                        Teacher = t4,
                        Students = new List<Student>()
                        {
                            s7
                        }
                    }
                }.AsQueryable()); 

            icl = new ClassroomLogic(mockCourseRepo.Object);
        }

        [Test]
        public void Test1()
        {
            int count = icl.ClassroomCount();

            Assert.That(count, Is.EqualTo(4));
        }

        [Test] // CREATE
        public void CreateTest()
        {
            Assert.That(() => icl.Create(new Classroom { }), Throws.Exception);
        }  

        [Test] // NON-CRUD
        public void ClassroomsWithYoungTeachersTest()
        {
            Assert.That(icl.ClassroomsWithYoungTeachers().Count(), Is.EqualTo(2));
        }

        [Test] // NON-CRUD
        public void ClassroomWithTheMostStudentTest()
        {
            Assert.That(icl.ClassroomWithTheMostStudent().Id, Is.EqualTo(3));
        }
    }
}
