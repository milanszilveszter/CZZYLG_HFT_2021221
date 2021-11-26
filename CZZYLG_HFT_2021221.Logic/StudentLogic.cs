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

        //public IEnumerable<KeyValuePair<string, int>>StudentCountByTeacher()
        //{
        //    return repo
        //         .ReadAll()
        //         .GroupBy(x => x.Teacher)
        //         .Select(x => new KeyValuePair<string, int>(
        //             x.Key.Name, x.Count()));
        //}

        public void Create(Student student)
        {
            if (student.StudentId < 0 || student.Name.Equals(null))
            {
                throw new ArgumentNullException();
            }
            else
            {
                repo.Create(student);
            }

        }
        public void Delete(int studentId)
        {
            repo.Delete(studentId);
        }
        public IQueryable<Student> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Student student)
        {
            if (student.StudentId < 0 || student.Name.Equals(null))
            {
                throw new ArgumentNullException();
            }
            else
            {
                repo.Update(student);
            }
        }
    }
}
