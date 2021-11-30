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
    [Route("[controller]/[action]")]
    [ApiController]
    public class QueriesController : ControllerBase
    {
        private IStudentLogic logic;

        public QueriesController(IStudentLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet] //  /student/[method_name]
        public IEnumerable<Student> StudentsWithOldTeacher()
        {
            return logic.StudentsWithOldTeachers();
        }
    }
}
