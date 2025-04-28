using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;


namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MarkController : ControllerBase
    {
        readonly IBlMark marks;

        public MarkController(IBL manager)
        {
            marks = manager.Marks;
        }
        [HttpPost("Add")]
        public BlMarks Create(BlMarks mark)
        {
            return marks.Create(mark);
        }
        [HttpPut("Update")]
        public int Update(BlMarks mark)
        {
           return marks.Update(mark);
        }
        [HttpDelete("Delete")]
        public void Delete(BlMarks mark)
        {
            marks.Delete(mark);
        }
    }
}
