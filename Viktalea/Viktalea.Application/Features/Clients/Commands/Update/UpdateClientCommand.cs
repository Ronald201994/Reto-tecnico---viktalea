using MediatR;

namespace Viktalea.Application.Features.Clients.Commands.Update
{
    public record UpdateClientCommand(
        int Id,
        string Ruc,
        string BusinessName,
        string ContactPhone,
        string ContactEmail,
        string Address) : IRequest<int>;
}
