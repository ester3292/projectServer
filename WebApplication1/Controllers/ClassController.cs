using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        IBlClass classes;

        public ClassController(IBL manager)
        {
            classes = manager.Classes;
        }
        [HttpPost("Add")]
        public void Create(BlClass myClass)
        {
            classes.Create(myClass);
        }
    }
}
