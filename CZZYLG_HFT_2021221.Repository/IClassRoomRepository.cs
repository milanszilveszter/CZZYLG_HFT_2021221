using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Repository
{
    public interface IClassRoomRepository
    {
        void Create(ClassRoom course);
        ClassRoom ReadOne(int id);
        IQueryable<ClassRoom> ReadAll();
        void Update(ClassRoom course);
        void Delete(int courseId);
    }
}
