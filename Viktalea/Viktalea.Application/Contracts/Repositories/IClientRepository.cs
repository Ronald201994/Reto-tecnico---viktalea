using Viktalea.Domain.Entities;

namespace Viktalea.Application.Contracts.Repositories
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<IEnumerable<Client>> GetByFilterAsync(string? ruc, string? businessName, CancellationToken cancellationToken);
    }
}
