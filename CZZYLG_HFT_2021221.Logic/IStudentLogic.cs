using CZZYLG_HFT_2021221.Models;
using System.Collections.Generic;

namespace CZZYLG_HFT_2021221.Logic
{
    public interface IStudentLogic
    {
        void Create(Student student);
        Student ReadOne(int studentId);
        IEnumerable<Student> ReadAll();
        void Update(Student student);
        void Delete(int studentId);

        double AllGradesAverage();
        IEnumerable<Student> StudentsInTheSameClassroom(int classroomId);
        IEnumerable<Student> StudentsWithOldTeachers();
        IEnumerable<KeyValuePair<string, double>> AvgGradesByClassroom();
    }
}
