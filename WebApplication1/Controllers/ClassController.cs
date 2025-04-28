using BL.Api;
using BL.Models;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        readonly IBlClass classes;

        public ClassController(IBL manager)
        {
            classes = manager.Classes;
        }
        [HttpPost("Add")]
        public void Create(BlClass myClass)
        {
            classes.Create(myClass);
        }
        [HttpGet("GetClassNameById")]
        public string GetClassNameById(int myclass)
        {
            return classes.GetClassNameById(myclass);
        }
    }
}
