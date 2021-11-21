using CZZYLG_HFT_2021221.Models;
using CZZYLG_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Logic
{
    class CourseLogic : ICourseLogic
    {
        ICourseRepository repo;

        public CourseLogic(ICourseRepository repo)
        {
            this.repo = repo;
        }

        public void Create(Course course)
        {
            repo.Create(course);
        }
        public void Delete(int courseId)
        {
            repo.Delete(courseId);
        }
        public IQueryable<Course> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Course course)
        {
            repo.Update(course);
        }
    }
}
