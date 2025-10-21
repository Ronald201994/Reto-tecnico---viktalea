using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Viktalea.Application.Dtos;
using Viktalea.Application.Features.Clients.Commands.Create;
using Viktalea.Application.Features.Clients.Commands.Delete;
using Viktalea.Application.Features.Clients.Commands.Update;
using Viktalea.Application.Features.Clients.Querys.GetClientsByFilter;

namespace Viktalea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController(IMediator mediator) : ControllerBase
    {
        //[HttpGet()]
        //[ProducesResponseType(typeof(IEnumerable<ClientDto>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<IEnumerable<ClientDto>>> GetProducts()
        //{
        //    var query = new GetProductListQuery();
        //    var clients = await mediator.Send(query);

        //    return Ok(clients);
        //}

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClientDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClientsByFilters([FromQuery] string? ruc, [FromQuery] string? businessName, CancellationToken cancellationToken)
        {
            var query = new GetClientsByFilterQuery(ruc, businessName);
            var clients = await mediator.Send(query, cancellationToken);
            return Ok(clients);
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateClient([FromBody] CreateClientCommand command)
        {
            return await mediator.Send(command);
        }

        [HttpPut()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateProduct([FromBody] UpdateClientCommand command)
        {
            return await mediator.Send(command);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> DeleteClient(int id)
        {
            return await mediator.Send(new DeleteClientCommand(id));
        }
    }
}
