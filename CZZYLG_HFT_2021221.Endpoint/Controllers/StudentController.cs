using CZZYLG_HFT_2021221.Logic;
using CZZYLG_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CZZYLG_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentLogic logic;

        public StudentController(IStudentLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return logic.ReadAll();
        }

        [HttpPost]
        public void AddOne([FromBody] Student student)
        {
            logic.Create(student);
        }

        [HttpPut]
        public void EditOne([FromBody] Student student)
        {
            logic.Update(student);
        }

        [HttpDelete("{studentId}")]
        public void DeleteOne([FromRoute] int studentId)
        {
            logic.Delete(studentId);
        }
    }
}
