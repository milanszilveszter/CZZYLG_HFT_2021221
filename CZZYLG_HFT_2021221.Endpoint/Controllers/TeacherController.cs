using CZZYLG_HFT_2021221.Endpoint.Services;
using CZZYLG_HFT_2021221.Logic;
using CZZYLG_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace CZZYLG_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherLogic logic;
        private readonly IHubContext<SignalRHub> hub;

        public TeacherController(ITeacherLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("TeacherCreated", teacher);
        }

        [HttpPut]
        public void EditOne([FromBody] Teacher teacher)
        {
            logic.Update(teacher);
            hub.Clients.All.SendAsync("TeacherUpdated", teacher);
        }

        [HttpDelete("{teacherId}")]
        public void DeleteOne([FromRoute] int teacherId)
        {
            var teacherToDelete = this.logic.ReadOne(teacherId);
            logic.Delete(teacherId);
            hub.Clients.All.SendAsync("TeacherDeleted", teacherToDelete);
        }
    }
}
