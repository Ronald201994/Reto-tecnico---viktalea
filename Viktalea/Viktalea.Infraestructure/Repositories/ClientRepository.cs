using Microsoft.EntityFrameworkCore;
using Viktalea.Application.Contracts.Repositories;
using Viktalea.Domain.Entities;
using Viktalea.Infraestructure.Persistence;

namespace Viktalea.Infraestructure.Repositories
{
    public class ClientRepository(ViktaleaContext context) : BaseRepository<Client>(context), IClientRepository
    {
        public async Task<IEnumerable<Client>> GetByFilterAsync(string? ruc, string? businessName, CancellationToken cancellationToken)
        {
            IQueryable<Client> query = context
                .Set<Client>()
                .AsNoTracking()
                .Where(c => c.IsActive!.Value);

            if (!string.IsNullOrWhiteSpace(ruc))
            {
                query = query.Where(c => EF.Functions.Like(c.Ruc, $"%{ruc}%"));
            }

            if (!string.IsNullOrWhiteSpace(businessName))
            {
                query = query.Where(c => EF.Functions.Like(c.BusinessName, $"%{businessName}%"));
            }

            return await query
                .OrderBy(c => c.BusinessName)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
