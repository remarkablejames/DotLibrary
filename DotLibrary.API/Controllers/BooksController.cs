using DotLibrary.Application.Features.Book.Commands.CreateBook;
using DotLibrary.Application.Features.Book.Queries.GetAllBooks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public async Task<List<BookDto>> Get()
        {
            var allBooks = await _mediator.Send(new GetAllBooksQuery());
            return allBooks;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<int> Post([FromBody] CreateBookCommand createBookCommand)
        {
            return await _mediator.Send(createBookCommand);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
