﻿using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Repository
{
    interface ICourseRepository
    {
        void Create(Course course);
        Course ReadOne(int id);
        IQueryable<Course> ReadAll();
        void Update(Course course);
        void Delete(int courseId);
    }
}
