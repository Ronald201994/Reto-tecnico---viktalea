using Viktalea.Domain.Entities;

namespace Viktalea.Application.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        Task<T?> GetByIdAsync(int id);
        void DeleteEntity(T entity);
    }
}
