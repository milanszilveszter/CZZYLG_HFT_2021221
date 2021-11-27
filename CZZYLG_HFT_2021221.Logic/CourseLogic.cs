using CZZYLG_HFT_2021221.Models;
using CZZYLG_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Logic
{
    public class CourseLogic : ICourseLogic
    {
        ICourseRepository repo;

        public CourseLogic(ICourseRepository repo)
        {
            this.repo = repo;
        }

        public int CoursesCount()
        {
            return repo.ReadAll().Count();
        }

        public void Create(Course course)
        {
            if (course.Id < 0 || course.CourseName.Equals(null))
            {
                throw new ArgumentNullException();
            }
            else
            {
                repo.Create(course);
            }
        }
        public void Delete(int courseId)
        {
            repo.Delete(courseId);
        }
        public IEnumerable<Course> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Course course)
        {
            if (course.Id < 0 || course.CourseName.Equals(null))
            {
                throw new ArgumentNullException();
            }
            else
            {
                repo.Update(course);
            }
        }
    }
}
