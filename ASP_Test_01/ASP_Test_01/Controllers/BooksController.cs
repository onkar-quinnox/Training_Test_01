using ASP_Test_01.Model;
using ASP_Test_01.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP_Test_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var res = bookRepository.GetBooks();

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            var res = bookRepository.AddBook(book);

            return Created(res.Id.ToString(), res);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var res = bookRepository.DeleteBook(id);
            if (res == -1)
            {
                return NotFound("Record not found");
            }
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook( [FromBody] Book book, [FromRoute] int id)
        {
            var res = bookRepository.UpdateBook(id, book);
            if (res == null)
            {
                return NotFound(id);
            }
            return Ok(res);
        }
    }
}
