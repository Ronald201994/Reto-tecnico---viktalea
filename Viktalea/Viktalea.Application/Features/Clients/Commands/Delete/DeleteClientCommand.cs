using MediatR;

namespace Viktalea.Application.Features.Clients.Commands.Delete
{
    public record DeleteClientCommand(int Id) : IRequest<int>;
}
