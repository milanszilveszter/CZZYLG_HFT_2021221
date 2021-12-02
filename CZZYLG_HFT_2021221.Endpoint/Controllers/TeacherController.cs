using CZZYLG_HFT_2021221.Logic;
using CZZYLG_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CZZYLG_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherLogic logic;

        public TeacherController(ITeacherLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Teacher> GetAll()
        {
            return logic.ReadAll();
        }

        [HttpPost]
        public void AddOne([FromBody] Teacher teacher)
        {
            logic.Create(teacher);
        }

        [HttpPut]
        public void EditOne([FromBody] Teacher teacher)
        {
            logic.Update(teacher);
        }

        [HttpDelete("{teacherId}")]
        public void DeleteOne([FromRoute] int teacherId)
        {
            logic.Delete(teacherId);
        }
    }
}
