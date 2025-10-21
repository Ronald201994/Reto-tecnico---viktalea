using AutoMapper;
using MediatR;
using Viktalea.Application.Contracts.Repositories;
using Viktalea.Domain.Entities;

namespace Viktalea.Application.Features.Clients.Commands.Update
{
    internal sealed class UpdateClientCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateClientCommand, int>
    {
        public async Task<int> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var clientToUpdate = await unitOfWork.Repository<Client>().GetByIdAsync(request.Id);

            if (clientToUpdate == null)
                throw new KeyNotFoundException($"Client with Id {request.Id} was not found.");

            mapper.Map(request, clientToUpdate);

            unitOfWork.Repository<Client>().UpdateEntity(clientToUpdate);

            var result = await unitOfWork.Complete();

            return result;
        }
    }
}
