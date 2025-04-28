using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL.Models;
using BL.Service;
using BL.Api;



namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IBlStudent students;

        public StudentController(IBL manager)
        {
            students = manager.Students;
        }

        [HttpGet("GetAll")]
        public List<BlStudent> Get()
        {
            return students.Get();
        }

        [HttpGet("GetMarkByClass")]
        public List<BlStudentAndMark> GetMarkByClass(string sub,int myclass)
        {
            return students.GetMarksInSubject(sub,myclass);
        }

        [HttpGet("GetMarkByClassAndHalf")]
        public List<BlStudentAndMark> GetMarkByClassAndHalf(string sub, int myclass,int halfA)
        {
            return students.GetMarksInSubjectInHalf(sub, myclass,halfA);
        }

        [HttpGet("GetAllSubjectsForClass")]
        public List<string> GetAllSubjectsForClass(int myclass)
        {
            return students.GetAllSubjectsForClass(myclass);
        }

        [HttpGet("GetFullAchivmentForStudentByFullName")]
        public BlStudentAchivment GetFullAchivmentForStudentByFullName(string firstName,string lastName)
        {
            return students.getFullAchivmentForStudentByFullName(firstName, lastName);
        }

        [HttpGet("GetFullAchivmentForStudentById")]
        public BlStudentAchivment GetFullAchivmentForStudentById(int id)
        {
            return students.getFullAchivmentForStudentById(id);
        }

        [HttpGet("GetById/{id}")]
        public BlStudent GetById(int id)
        {
            return students.GetById(id);
        }

        [HttpPost("Add")]
        public BlStudent Create(BlStudent student)
        {
           return students.Create(student);
        }
       

        [HttpPut("Update")]
        public void Update(BlStudent student)
        {
            students.Update(student);
        }

        [HttpDelete("Delete")]
        public List<BlStudent> Delete(BlStudent student)
        {
            students.Delete(student);
            return students.Get();
        }
    }
}
