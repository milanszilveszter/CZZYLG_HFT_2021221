using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Repository
{
    interface IStudentRepository
    {
        public void Create(Student course);
        public Student ReadOne(int id);
        public IQueryable<Student> ReadAll();
        public void Update(Student course);
        public void Delete(int courseId);
    }
}
