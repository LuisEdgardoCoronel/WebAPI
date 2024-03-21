using Microsoft.AspNetCore.Mvc;
using PracticaEf.Model;
using WebAPI.Service;

namespace WebAPI.Controllers

{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categoryService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category) 
        {
            categoryService.Save(category);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Category category)
        {
            categoryService.Update(id, category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            categoryService.Delete(id);
            return Ok();
        }
    }
}
