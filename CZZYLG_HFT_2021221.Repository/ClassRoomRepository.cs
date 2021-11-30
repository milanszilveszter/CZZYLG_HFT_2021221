using CZZYLG_HFT_2021221.Data;
using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        SchoolContext context;

        public ClassroomRepository(SchoolContext context)
        {
            this.context = context;
        }

        public void Create(Classroom classroom)
        {
            context.Classrooms.Add(classroom);
            context.SaveChanges();
        }
        public Classroom ReadOne(int id)
        {
            return context
                .Classrooms
                .FirstOrDefault(c => c.Id == id);
        }
        public IQueryable<Classroom> ReadAll()
        {
            return context.Classrooms;
        }
        public void Update(Classroom classroom)
        {
            Classroom old = ReadOne(classroom.Id);

            old.Id = classroom.Id;
            old.ClassroomNumber = classroom.ClassroomNumber;

            context.SaveChanges();
        }
        public void Delete(int classroomId)
        {
            context.Classrooms.Remove(ReadOne(classroomId));
            context.SaveChanges();
        }
    }
}
