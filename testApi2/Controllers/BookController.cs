using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testApi2.Data;
using testApi2.Model;

namespace testApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Book>>> GetBooks()
        {
            try
            {
                IList<Book> books = await _bookService.GetBookAsync();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _bookService.AddBookAsync(book);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        // [HttpDelete]
        // public async Task<ActionResult<Book>> DeleteBook(int ISBN)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //
        //     
        //     try
        //     {
        //        Book deletedBook =  await _bookService.DeleteBookAsync(ISBN)
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e);
        //         throw;
        //     }
        // }
    } 
}
