﻿using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Repository
{
    public interface ITeacherRepository
    {
        void Create(Teacher teacher);
        Teacher ReadOne(int id);
        IQueryable<Teacher> ReadAll();
        void Update(Teacher teacher);
        void Delete(int teacherId);
    }
}
