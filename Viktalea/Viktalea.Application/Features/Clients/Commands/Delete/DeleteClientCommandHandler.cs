using MediatR;
using Viktalea.Application.Contracts.Repositories;
using Viktalea.Domain.Entities;

namespace Viktalea.Application.Features.Clients.Commands.Delete
{
    internal sealed class DeleteClientCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteClientCommand, int>
    {
        public async Task<int> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await unitOfWork.Repository<Client>().GetByIdAsync(request.Id);

            if (client is null)
                throw new KeyNotFoundException($"Client with Id {request.Id} was not found.");

            // Marcar como eliminado (soft delete)
            unitOfWork.Repository<Client>().DeleteEntity(client);

            return await unitOfWork.Complete();
        }
    }
}
