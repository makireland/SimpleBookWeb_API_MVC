using Microsoft.AspNetCore.Mvc;
using SimpleBookWeb.Domain.Dtos;
using SimpleBookWeb.BLL.InterfaceServices;

namespace SimpleBookWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.GetAll());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _categoryService.GetById(id));
        }

        // POST api/<CategoryController>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _categoryService.Add(categoryDto));
        }

        // PUT api/<CategoryController>/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromBody] CategoryDto categoryDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _categoryService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            var result = await _categoryService.Update(categoryDto);

            return Ok(result);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(await _categoryService.Delete(category));
        }
    }
}
