using CZZYLG_HFT_2021221.Models;
using System.Collections.Generic;

namespace CZZYLG_HFT_2021221.Logic
{
    public interface IClassroomLogic
    {
        void Create(Classroom classroom);
        IEnumerable<Classroom> ReadAll();
        void Update(Classroom classroom);
        void Delete(int classroomId);

        int ClassroomCount();
        public IEnumerable<Classroom> ClassroomsWithYoungTeachers();
        public Classroom ClassroomWithTheMostStudent();
    }
}
