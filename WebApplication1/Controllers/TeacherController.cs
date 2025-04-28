using BL.Api;
using BL.Models;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        IBlTeacher teachers;
        public TeacherController(IBL manager)
        {
            teachers = manager.Teachers;
        }
        [HttpGet("GetAll")]
        public List<BlTeacher> Get()
        {
            return teachers.Get();
        }
        [HttpGet("GetById/{id}")]
        public BlTeacher GetById(int id)
        {
            return teachers.GetById(id);
        }
        [HttpGet("GetStudents/{myClass}")]
        public List<BlStudent> Get(int myClass)
        {
            return teachers.GetStudentsForEducationTeacher(myClass);
        }
        [HttpPost("Add")]
        public List<BlTeacher> Create(BlTeacher teacher)
        {
           return teachers.Create(teacher);
        }
       
        [HttpPut("Update")]
        public List<BlTeacher> Update(BlTeacher teacher)
        {
            return teachers.Update(teacher);
        }
        [HttpDelete("Delete")]
        public List<BlTeacher> Delete(BlTeacher teacher)
        {
            teachers.Delete(teacher);
            return teachers.Get();
        }
    }
}
