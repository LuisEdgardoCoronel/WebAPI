using Microsoft.AspNetCore.Mvc;
using PracticaEf;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class FirstController:ControllerBase
    {
        IFirstService firstService;

        TaskContext dbcontext;
        public FirstController(IFirstService firstService, TaskContext context)
        {
            this.firstService = firstService;
            dbcontext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(firstService.GetFirst());
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDatabase()
        {
            dbcontext.Database.EnsureCreated();
            return Ok();
        }
    }
}
