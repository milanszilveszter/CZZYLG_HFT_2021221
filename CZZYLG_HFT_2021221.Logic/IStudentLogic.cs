using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Logic
{
    public interface IStudentLogic
    {
        void Create(Student student);
        IQueryable<Student> ReadAll();
        void Update(Student student);
        void Delete(int studentId);

        double AllGradesAverage();

        //IEnumerable<KeyValuePair<string, int>>StudentCountByTeacher();
    }
}
