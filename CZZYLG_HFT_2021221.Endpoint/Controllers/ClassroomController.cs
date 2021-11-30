using CZZYLG_HFT_2021221.Logic;
using CZZYLG_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CZZYLG_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private IClassroomLogic logic;

        public ClassroomController(IClassroomLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Classroom> GetAll()
        {
            return logic.ReadAll();
        }

        [HttpPost]
        public void AddOne([FromBody] Classroom course)
        {
            logic.Create(course);
        }

        [HttpPut]
        public void EditOne([FromBody] Classroom course)
        {
            logic.Update(course);
        }

        [HttpDelete("{courseId}")]
        public void DeleteOne([FromRoute] int courseId)
        {
            logic.Delete(courseId);
        }
    }
}
