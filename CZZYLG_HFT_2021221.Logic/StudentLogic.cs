using CZZYLG_HFT_2021221.Models;
using CZZYLG_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Logic
{
    public class StudentLogic : IStudentLogic
    {
        IStudentRepository repo;

        public StudentLogic(IStudentRepository repo)
        {
            this.repo = repo;
        }

        public double AllGradesAverage()
        {
            return repo
                .ReadAll()
                .Average(s => s.Grade);
        }

        public IEnumerable<Student> StudentsInTheSameClassroom(int classroomId)
        {
            return from x in repo.ReadAll()
                   where x.ClassroomId == classroomId
                   select x;
        }

        public IEnumerable<Student> StudentsWithOldTeachers()
        {
            

            return from s in repo.ReadAll()
                   where s.Classroom.Teacher.Age > 50
                   select s;

        }

        public IEnumerable<KeyValuePair<string, double>> AvgGradesByClassroom()
        {
            return repo
                .ReadAll()
                .GroupBy(x => x.Classroom.ClassroomNumber)
                .Select(x => new KeyValuePair<string, double>(
                    x.Key, x.Average(c => c.Grade)));
        }     

        public void Create(Student student)
        {
            if (student.Id < 0 || student.Name.Equals(null))
            {
                throw new ArgumentNullException();
            }
            else
            {
                repo.Create(student);
            }

        }
        public IEnumerable<Student> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Student student)
        {
            if (student.Id < 0 || student.Name.Equals(null))
            {
                throw new ArgumentNullException();
            }
            else
            {
                repo.Update(student);
            }
        }
        public void Delete(int studentId)
        {
            repo.Delete(studentId);
        }

    }
}
