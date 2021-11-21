﻿using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Repository
{
    public interface IStudentRepository
    {
        void Create(Student course);
        Student ReadOne(int id);
        IQueryable<Student> ReadAll();
        void Update(Student course);
        void Delete(int courseId);
    }
}