using CZZYLG_HFT_2021221.Data;
using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .FirstOrDefault(s => s.StudentId == id);
        }
        public IQueryable<Student> ReadAll()
        {
            return context.Students;
        }
        public void Update(Student student)
        {
            Student old = ReadOne(student.StudentId);

            old.Name = student.Name;
            old.Grade = student.Grade;

            context.SaveChanges();
        }
        public void Delete(int studentId)
        {
            context.Students.Remove(ReadOne(studentId));
            context.SaveChanges();
        }    
    }
}
