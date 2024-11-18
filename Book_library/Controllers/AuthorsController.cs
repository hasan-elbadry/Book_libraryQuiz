using Book_library.Dtos.AuthorDtos;
using Book_library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Author_library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _AuthorRepsitory;

        public AuthorsController(IAuthorRepository AuthorRepsitory)
        {
            _AuthorRepsitory = AuthorRepsitory;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            return Ok(_AuthorRepsitory.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAuthorById(int id)
        {
            return Ok(_AuthorRepsitory.GetById(id));
        }

        [HttpPost]
        public IActionResult CreateAuthor(CreateAuthorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = _AuthorRepsitory.Add(dto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAuthor(int id, CreateAuthorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = _AuthorRepsitory.Update(id, dto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAuthor(int id)
        {
            var result = _AuthorRepsitory.Delete(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
