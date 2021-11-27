﻿using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Logic
{
    public interface ICourseLogic
    {
        void Create(Course course);
        IEnumerable<Course> ReadAll();
        void Update(Course course);
        void Delete(int courseId);

        int CoursesCount();
    }
}
