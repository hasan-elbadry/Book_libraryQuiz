using Book_library.Dtos.BookDtos;
using Book_library.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepsitory _bookRepsitory;

        public BooksController(IBookRepsitory bookRepsitory)
        {
            _bookRepsitory = bookRepsitory;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_bookRepsitory.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBookById(int id)
        {
            return Ok(_bookRepsitory.GetById(id));
        }

        [HttpPost]
        public IActionResult CreateBook(CreateBookDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = _bookRepsitory.Add(dto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBook(int id,CreateBookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = _bookRepsitory.Update(id,dto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            var result = _bookRepsitory.Delete(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
