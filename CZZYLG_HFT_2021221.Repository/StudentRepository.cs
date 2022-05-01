using CZZYLG_HFT_2021221.Data;
using CZZYLG_HFT_2021221.Models;
using System.Linq;

namespace CZZYLG_HFT_2021221.Repository
{
    public class StudentRepository : IStudentRepository
    {
        SchoolContext context;

        public StudentRepository(SchoolContext context)
        {
            this.context = context;
        }

        public void Create(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }
        public Student ReadOne(int id)
        {
            return context
                .Students
                .FirstOrDefault(s => s.Id == id);
        }
        public IQueryable<Student> ReadAll()
        {
            return context.Students;
        }
        public void Update(Student student)
        {
            Student old = ReadOne(student.Id);
           
            old.Id = student.Id;
            old.Name = student.Name;
            old.Grade = student.Grade;
            old.ClassroomId = student.ClassroomId;

            context.SaveChanges();
        }
        public void Delete(int studentId)
        {
            context.Students.Remove(ReadOne(studentId));
            context.SaveChanges();
        }
    }
}
