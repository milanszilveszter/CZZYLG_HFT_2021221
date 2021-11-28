using CZZYLG_HFT_2021221.Data;
using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Repository
{
    public class ClassRoomRepository : IClassroomRepository
    {
        SchoolContext context;

        public ClassRoomRepository(SchoolContext context)
        {
            this.context = context;
        }

        public void Create(Classroom course)
        {
            context.Classrooms.Add(course);
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
            old.TeacherId = classroom.TeacherId;

            context.SaveChanges();
        }
        public void Delete(int courseId)
        {
            context.Classrooms.Remove(ReadOne(courseId));
            context.SaveChanges();
        }
    }
}
