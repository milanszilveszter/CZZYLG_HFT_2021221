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
        private IStudentLogic isl;
        private IClassroomLogic icl;
        private ITeacherLogic itl;

        public QueriesController(IStudentLogic isl, IClassroomLogic icl, ITeacherLogic itl)
        {
            this.isl = isl;
            this.icl = icl;
            this.itl = itl;
        }

        // STUDENT METHODS  /queries/[method_name]
        [HttpGet] 
        public double AllGradesAverage()
        {
            return isl.AllGradesAverage();
        }

        [HttpGet] 
        public IEnumerable<Student> StudentsWithOldTeacher()
        {
            return isl.StudentsWithOldTeachers();
        }

        [HttpGet("{classroomId}")]
        public IEnumerable<Student> StudentsInTheSameClassroom([FromRoute] int classroomId)
        {
            return isl.StudentsInTheSameClassroom(classroomId);
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AvgGradesByClassroom()
        {
            return isl.AvgGradesByClassroom();
        }

        // CLASSROOM METHODS
        [HttpGet]
        public int ClassroomCount()
        {
            return icl.ClassroomCount();
        }

        [HttpGet]
        public IEnumerable<Classroom> ClassroomsWithYoungTeachers()
        {
            return icl.ClassroomsWithYoungTeachers();
        }

        [HttpGet]
        public Classroom ClassroomWithTheMostStudent()
        {
            return icl.ClassroomWithTheMostStudent();
        }

        // TEACHER METHODS
        [HttpGet]
        public double AgeAverage()
        {
            return itl.AgeAverage();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, Student>> WorstStudentsByTeachers()
        {
            return itl.WorstStudentsByTeachers();
        }
    }
}
