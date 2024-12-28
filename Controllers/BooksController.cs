using _03_onlinelibrary_api.Communications.Requests;
using _03_onlinelibrary_api.Entities;
using _03_onlinelibrary_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace _03_onlinelibrary_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(BookServices bookServices) : ControllerBase
    {
        private readonly BookServices _bookServices = bookServices;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateBook([FromBody] RequestCreateBookJson request)
        {
            var book = new Book
            {
                Id = _bookServices.GetBooks().Count + 1,
                Title = request.Title,
                Author = request.Author,
                Gender = request.Gender,
                Price = request.Price,
                Amount = 0,
            };

            _bookServices.AddBook(book);

            return Ok(book);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_bookServices.GetBooks());
        }
    }
}
