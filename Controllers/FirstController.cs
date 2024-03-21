using Microsoft.AspNetCore.Mvc;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class FirstController:ControllerBase
    {
        IFirstService firstService;

        public FirstController(IFirstService firstService)
        {
            this.firstService = firstService;
        }
        [HttpGet(Name = "GetFirst")]
        public IActionResult Get()
        {
            return Ok(firstService.GetFirst());
        }
    }
}
