using CZZYLG_HFT_2021221.Models;
using CZZYLG_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Logic
{
    public class ClassRoomLogic : IClassRoomLogic
    {
        IClassroomRepository repo;

        public ClassRoomLogic(IClassroomRepository repo)
        {
            this.repo = repo;
        }

        public int CoursesCount()
        {
            return repo.ReadAll().Count();
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
