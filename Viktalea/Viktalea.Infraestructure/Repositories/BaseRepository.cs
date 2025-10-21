using Microsoft.EntityFrameworkCore;
using Viktalea.Application.Contracts.Repositories;
using Viktalea.Domain.Entities;
using Viktalea.Infraestructure.Persistence;

namespace Viktalea.Infraestructure.Repositories
{
    public class BaseRepository<T>(ViktaleaContext context) : IBaseRepository<T> where T : BaseDomainModel
    {
        public void AddEntity(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public void UpdateEntity(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public void DeleteEntity(T entity)
        {
            context.Set<T>().Remove(entity);
        }
    }
}
