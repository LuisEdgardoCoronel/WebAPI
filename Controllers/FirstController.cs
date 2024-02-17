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

        public IActionResult Get()
        {
            return Ok(firstService.GetFirst());
        }
    }
}
