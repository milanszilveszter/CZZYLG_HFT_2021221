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
    public class ClassroomController : ControllerBase
    {
        private IClassroomLogic logic;
        private readonly IHubContext<SignalRHub> hub;

        public ClassroomController(IClassroomLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Classroom> GetAll()
        {
            return logic.ReadAll();
        }

        [HttpPost]
        public void AddOne([FromBody] Classroom classroom)
        {
            logic.Create(classroom);
            hub.Clients.All.SendAsync("ClassroomCreated", classroom);
        }

        [HttpPut]
        public void EditOne([FromBody] Classroom classroom)
        {
            logic.Update(classroom);
            hub.Clients.All.SendAsync("ClassroomUpdated", classroom);
        }

        [HttpDelete("{classroomId}")]
        public void DeleteOne([FromRoute] int classroomId)
        {
            var classroomToDelete = this.logic.ReadOne(classroomId);
            logic.Delete(classroomId);
            hub.Clients.All.SendAsync("ClassroomDeleted", classroomToDelete);
        }
    }
}
