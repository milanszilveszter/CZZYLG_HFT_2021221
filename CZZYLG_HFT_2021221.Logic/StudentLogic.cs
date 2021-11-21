using CZZYLG_HFT_2021221.Models;
using CZZYLG_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Logic
{
    class StudentLogic : IStudentLogic
    {
        IStudentRepository repo;

        public StudentLogic(IStudentRepository repo)
        {
            this.repo = repo;
        }

        public float AllGradesAverage()
        {
            return repo
                .ReadAll()
                .Average(s => s.GradeAvg);
        }

        public void Create(Student student)
        {
            repo.Create(student);
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
            repo.Update(student);
        }
    }
}
