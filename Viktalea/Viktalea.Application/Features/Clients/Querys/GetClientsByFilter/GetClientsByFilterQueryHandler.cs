using AutoMapper;
using MediatR;
using Viktalea.Application.Contracts.Repositories;
using Viktalea.Application.Dtos;

namespace Viktalea.Application.Features.Clients.Querys.GetClientsByFilter
{
    internal sealed class GetClientsByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<GetClientsByFilterQuery, IEnumerable<ClientDto>>
    {
        public async Task<IEnumerable<ClientDto>> Handle(GetClientsByFilterQuery request, CancellationToken cancellationToken)
        {
            var clients = await unitOfWork.ClientRepository.GetByFilterAsync(request.Ruc, request.BusinessName, cancellationToken);

            return mapper.Map<IEnumerable<ClientDto>>(clients);
        }
    }
}