

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
    
    public class AuthorController : ControllerBase
    {
        private IAuthorService AuthorService;

        public AuthorController(IAuthorService authorService)
        {
            AuthorService = authorService;
        }

        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor(Author author)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await AuthorService.AddAuthorAsync(author);
                return Ok();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IList<Author>>> GetAuthors()
        {
            try
            {
                IList<Author> authors = await AuthorService.GetAuthorsAsync();
                return Ok(authors);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}