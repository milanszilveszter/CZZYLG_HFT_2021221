using CZZYLG_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;

namespace CZZYLG_HFT_2021221.Logic
{
    public interface ITeacherLogic
    {
        void Create(Teacher teacher);
        Teacher ReadOne(int teacherId);
        IQueryable<Teacher> ReadAll();
        void Update(Teacher teacher);
        void Delete(int teacherId);

        double AgeAverage();

        IEnumerable<KeyValuePair<string, Student>> WorstStudentsByTeachers();
    }
}
