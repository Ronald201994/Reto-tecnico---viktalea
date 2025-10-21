using MediatR;
using Viktalea.Application.Dtos;

namespace Viktalea.Application.Features.Clients.Querys.GetClientsByFilter
{
    public record GetClientsByFilterQuery(string? Ruc, string? BusinessName) : IRequest<IEnumerable<ClientDto>>;
}
