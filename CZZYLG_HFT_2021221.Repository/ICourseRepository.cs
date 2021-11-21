using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Repository
{
    interface ICourseRepository
    {
        public void Create(Course course);
        public Course ReadOne(int id);
        public IQueryable<Course> ReadAll();
        public void Update(Course course);
        public void Delete(int courseId);
    }
}
