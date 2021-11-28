using CZZYLG_HFT_2021221.Data;
using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Repository
{
    public class ClassRoomRepository : IClassRoomRepository
    {
        SchoolContext context;

        public ClassRoomRepository(SchoolContext context)
        {
            this.context = context;
        }

        public void Create(ClassRoom course)
        {
            context.ClassRooms.Add(course);
            context.SaveChanges();
        }
        public ClassRoom ReadOne(int id)
        {
            return context
                .ClassRooms
                .FirstOrDefault(c => c.Id == id);
        }
        public IQueryable<ClassRoom> ReadAll()
        {
            return context.ClassRooms;
        }
        public void Update(ClassRoom course)
        {
            ClassRoom old = ReadOne(course.Id);

            old.Id = course.Id;
            old.ClassRoomNumber = course.ClassRoomNumber;

            context.SaveChanges();
        }
        public void Delete(int courseId)
        {
            context.ClassRooms.Remove(ReadOne(courseId));
            context.SaveChanges();
        }
    }
}
