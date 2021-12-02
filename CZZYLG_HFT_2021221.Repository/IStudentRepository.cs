using CZZYLG_HFT_2021221.Models;
using System.Linq;

namespace CZZYLG_HFT_2021221.Repository
{
    public interface IStudentRepository
    {
        void Create(Student student);
        Student ReadOne(int id);
        IQueryable<Student> ReadAll();
        void Update(Student student);
        void Delete(int studentId);
    }
}
