using CZZYLG_HFT_2021221.Models;
using CZZYLG_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Logic
{
    class TeacherLogic : ITeacherLogic
    {
        ITeacherRepository repo;

        public TeacherLogic(ITeacherRepository repo)
        {
            this.repo = repo;
        }

        public double AgeAverage()
        {
            return repo.ReadAll().Average(x => x.Age);
        }

        public IEnumerable<Teacher> MostStudentsWithAvgGt3()
        {
            return (IEnumerable<Teacher>)repo
                .ReadAll()
                .Select(x => x.Students
                    .Where(s => s.GradeAvg >= 3f));
        }

        public void Create(Teacher teacher)
        {
            repo.Create(teacher);
        }
        public void Delete(int teacherId)
        {
            repo.Delete(teacherId);
        }
        public IQueryable<Teacher> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Teacher teacher)
        {
            repo.Update(teacher);
        }
    }
}
