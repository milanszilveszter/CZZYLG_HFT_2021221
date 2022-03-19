using CZZYLG_HFT_2021221.Endpoint.Services;
using CZZYLG_HFT_2021221.Logic;
using CZZYLG_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CZZYLG_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentLogic logic;
        private readonly IHubContext<SignalRHub> hub;
        public StudentController(IStudentLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("StudentCreated", student);
        }

        [HttpPut]
        public void EditOne([FromBody] Student student)
        {
            logic.Update(student);
            hub.Clients.All.SendAsync("StudentUpdated", student);
        }

        [HttpDelete("{studentId}")]
        public void DeleteOne([FromRoute] int studentId)
        {
            var studentToDelete = this.logic.ReadOne(studentId);
            logic.Delete(studentId);
            hub.Clients.All.SendAsync("StudentDeleted", studentToDelete);
        }
    }
}
