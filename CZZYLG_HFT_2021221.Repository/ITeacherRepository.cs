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
        void Create(Teacher course);
        Teacher ReadOne(int id);
        IQueryable<Teacher> ReadAll();
        void Update(Teacher course);
        void Delete(int courseId);
    }
}
