using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Logic
{
    public interface ITeacherLogic
    {
        void Create(Teacher teacher);
        IQueryable<Teacher> ReadAll();
        void Update(Teacher teacher);
        void Delete(int teacherId);

        double AgeAverage();

        IEnumerable<KeyValuePair<string, Student>> WorstStudentsByTeachers();
    }
}
