using books.Model;
using books.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBooksRepository _bookRepository;
        public BookController(IBooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        // GET: api/<BookController>
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_bookRepository.GetBooks());
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);

        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.InsertBook(book);
                return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
            }

            return Ok(book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("User is not exists in database");
            }

            var foundBook = _bookRepository.GetBookById(id);

            if (foundBook == null)
            {
                return NotFound();
            }

            // Update the properties of the existing order with the new values.
            foundBook.Title = book.Title;
            foundBook.Description = book.Description;
            foundBook.Author = book.Author;

            _bookRepository.UpdateBook(foundBook);
            return Ok(foundBook);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.DeleteBook(id);
            return Ok(book);

        }
    }
}
