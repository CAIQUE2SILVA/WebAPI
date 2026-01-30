using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookServices bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all books");
            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Getting book with id {Id}", id);
            var book = _bookService.FindById(id);
            if (book == null)
            {
                _logger.LogWarning("Book with id {Id} not found", id);
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
         
        public IActionResult Post([FromBody] Book book)
        {
            _logger.LogInformation("Creating a new book");
            var createdBook = _bookService.Create(book);
            if (createdBook == null)
            {
                _logger.LogWarning("Failed to create book: {Title}", book.Title);
                return NotFound();
            }
            return Ok(createdBook);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            _logger.LogInformation("Updating book with id {Id}", book.Id);
            var updatedBook = _bookService.Update(book);
            if (updatedBook == null)
            {
                _logger.LogWarning("Failed to update book with id {Id}", book.Id);
                return NotFound();
            }
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting book with id {Id}", id);
            _bookService.Delete(id);
            return NoContent();
        }



    }
}
