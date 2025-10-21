using MediatR;

namespace Viktalea.Application.Features.Clients.Commands.Create
{
    public record CreateClientCommand(
        string Ruc,
        string BusinessName,
        string ContactPhone,
        string ContactEmail,
        string Address) : IRequest<int>;
}
