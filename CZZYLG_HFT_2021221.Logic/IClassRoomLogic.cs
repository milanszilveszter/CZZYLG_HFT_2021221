using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Logic
{
    public interface IClassRoomLogic
    {
        void Create(Classroom classroom);
        IEnumerable<Classroom> ReadAll();
        void Update(Classroom classroom);
        void Delete(int classroomId);

        int ClassroomCount();
    }
}
