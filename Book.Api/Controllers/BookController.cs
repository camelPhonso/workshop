using Book.Api.Data;
using Microsoft.AspNetCore.Mvc;
using BookClass = Book.Api.Entities.Book;

namespace Book.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IBookContext _context; // This was not changed !

        public BookController(IBookContext context) // And here !
        {
            _context = context;
        }

        [HttpGet]
        public List<BookClass> GetAllBooks()
        {
            var result = _context.Books.ToList();
            return result;
        }

        [HttpGet]
        public ActionResult GetSingleBook(string name)
        {
            var targetBook = _context.Books.FirstOrDefault(book => book.Name == name);

            if(targetBook == null) return NotFound("Book not found");

            return Ok(targetBook);
        }
    }
}
