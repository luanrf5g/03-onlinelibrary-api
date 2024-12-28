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

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] int id)
        {
            var book = _bookServices.GetBookById(id);

            if (book == null)
                return NotFound("Book not found");

            return Ok(book);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateBook([FromBody] RequestUpdateBookJson request, [FromRoute] int id)
        {
            var book = _bookServices.GetBookById(id);

            book.Price = request.Price;
            book.Amount = request.Amount;

            _bookServices._books[id - 1] = book;

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            var book = _bookServices.GetBookById(id);

            _bookServices._books.Remove(book);

            return NoContent();
        }
    }
}
