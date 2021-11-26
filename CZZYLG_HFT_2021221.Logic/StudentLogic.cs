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
        public int CoursesCount()
        {
            return repo.ReadAll()
                .Sum(x => x.StudentCourses.Count());
        }
        public IEnumerable<Student> StudentsByCourse(int courseId)
        {
            return repo.ReadAll()
                .SelectMany(x => x.StudentCourses)
                .Where(x => x.CourseId == courseId)
                .Select(x => x.Student).AsEnumerable();
        }

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
        public IEnumerable<Student> ReadAll()
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
