using CZZYLG_HFT_2021221.Data;
using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Repository
{
    public class CourseRepository : ICourseRepository
    {
        SchoolContext context;

        public CourseRepository(SchoolContext context)
        {
            this.context = context;
        }

        public void Create(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }
        public Course ReadOne(int id)
        {
            return context
                .Courses
                .FirstOrDefault(c => c.CourseId == id);
        }
        public IQueryable<Course> ReadAll()
        {
            return context.Courses;
        }
        public void Update(Course course)
        {
            Course old = ReadOne(course.CourseId);

            old.CourseName = course.CourseName;
            old.CourseId = course.CourseId;

            context.SaveChanges();
        }
        public void Delete(int courseId)
        {
            context.Courses.Remove(ReadOne(courseId));
            context.SaveChanges();
        }
    }
}
