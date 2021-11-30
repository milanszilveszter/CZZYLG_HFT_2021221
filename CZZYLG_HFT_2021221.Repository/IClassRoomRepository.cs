using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Repository
{
    public interface IClassroomRepository
    {
        void Create(Classroom classroom);
        Classroom ReadOne(int id);
        IQueryable<Classroom> ReadAll();
        void Update(Classroom classroom);
        void Delete(int classroomId);
    }
}
