using CZZYLG_HFT_2021221.Models;
using CZZYLG_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Logic
{
    public class ClassroomLogic : IClassroomLogic
    {
        IClassroomRepository repo;

        public ClassroomLogic(IClassroomRepository repo)
        {
            this.repo = repo;
        }

        public int ClassroomCount()
        {
            return repo.ReadAll().Count();
        }

        public IEnumerable<Classroom> ClassroomsWithYoungTeachers()
        {
            return from x in repo.ReadAll()
                   where x.Teacher.Age < 30
                   select x;
        }

        public Classroom ClassroomWithTheMostStudent()
        {
            return repo.ReadAll().OrderByDescending(x => x.Students.Count()).FirstOrDefault();              
        }     

        public void Create(Classroom classRoom)
        {
            if (classRoom.Id < 0 || classRoom.ClassroomNumber.Equals(null))
            {
                throw new ArgumentNullException();
            }
            else
            {
                repo.Create(classRoom);
            }
        }
        public void Delete(int classRoomId)
        {
            repo.Delete(classRoomId);
        }
        public IEnumerable<Classroom> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Classroom course)
        {
            if (course.Id < 0 || course.ClassroomNumber.Equals(null))
            {
                throw new ArgumentNullException();
            }
            else
            {
                repo.Update(course);
            }
        }
    }
}
