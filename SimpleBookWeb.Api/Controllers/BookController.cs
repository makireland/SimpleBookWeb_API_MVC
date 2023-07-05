using Microsoft.AspNetCore.Mvc;
using SimpleBookWeb.Domain.Dtos;
using SimpleBookWeb.BLL.InterfaceServices;

namespace SimpleBookWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookService.GetAll());
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _bookService.GetById(id));
        }

        // POST api/<BookController>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] BookDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _bookService.Add(book));
        }

        // PUT api/<BookController>/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromBody] BookDto bookDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }
             var result = await _bookService.Update(bookDto);

            return Ok(result);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(await _bookService.Delete(book));
        }
    }
}


