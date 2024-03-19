using DotLibrary.Application.Features.Publisher.Queries.GetPublisherDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PublishersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<PublishersController>
        [HttpGet]
        public  IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PublishersController>/5
        [HttpGet("{id}")]
        public async Task<PublisherDetailsDto> Get(int id)
        {
            return  await _mediator.Send(new GetPublisherDetailsQuery(id));
        }
        

        // POST api/<PublishersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PublishersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PublishersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
