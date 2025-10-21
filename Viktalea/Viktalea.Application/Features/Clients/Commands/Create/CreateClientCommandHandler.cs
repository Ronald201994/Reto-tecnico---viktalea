using AutoMapper;
using MediatR;
using Viktalea.Application.Contracts.Repositories;
using Viktalea.Domain.Entities;

namespace Viktalea.Application.Features.Clients.Commands.Create
{
    internal sealed class CreateClientCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<CreateClientCommand, int>
    {
        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = mapper.Map<Client>(request);

            unitOfWork.Repository<Client>().AddEntity(client);

            var result = await unitOfWork.Complete();

            return result;
        }
    }
}
