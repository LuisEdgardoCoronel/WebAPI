using Microsoft.AspNetCore.Mvc;
using PracticaEf.Model;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TasksController: ControllerBase
    {
        ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(taskService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] TaskModel task)
        {
            taskService.Save(task);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TaskModel task)
        {
            taskService.Update(id, task);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            taskService.Delete(id);
            return Ok();
        }
    }
}
