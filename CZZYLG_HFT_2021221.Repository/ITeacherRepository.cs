using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Repository
{
    interface ITeacherRepository
    {
        public void Create(Teacher course);
        public Teacher ReadOne(int id);
        public IQueryable<Teacher> ReadAll();
        public void Update(Teacher course);
        public void Delete(int courseId);
    }
}
