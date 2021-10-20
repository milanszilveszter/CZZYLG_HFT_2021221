using CZZYLG_HFT_2021221.Data;
using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Repository
{
    public class TeacherRepository
    {
        SchoolContext context;

        public TeacherRepository(SchoolContext context)
        {
            this.context = context;
        }

        public void Create(Teacher teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();
        }
        public Teacher ReadOne(int id)
        {
            return context
                .Teachers
                .FirstOrDefault(t => t.TeacherId == id);
        }
        public IQueryable<Teacher> ReadAll()
        {
            return context.Teachers;
        }
        public void Update(Teacher teacher)
        {
            Teacher old = ReadOne(teacher.TeacherId);

            old.Name = teacher.Name;
            old.TeacherId = teacher.TeacherId;            

            context.SaveChanges();
        }
        public void Delete(int teacherId)
        {
            context.Teachers.Remove(ReadOne(teacherId));
            context.SaveChanges();
        }
    }
}
