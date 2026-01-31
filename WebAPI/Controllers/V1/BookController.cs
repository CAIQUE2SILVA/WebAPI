using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.DTO.V1;
using WebAPI.Services;

namespace WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]/v1")]
    [Produces("application/json")]

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
        [ProducesResponseType(200, Type = typeof(List<BookDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all books");
            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
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
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] BookDTO book)
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
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] BookDTO book)
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
        [ProducesResponseType(204, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting book with id {Id}", id);
            _bookService.Delete(id);
            return NoContent();
        }



    }
}
