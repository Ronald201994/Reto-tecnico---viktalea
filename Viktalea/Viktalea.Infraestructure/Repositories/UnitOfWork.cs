using System.Collections;
using Viktalea.Application.Contracts.Repositories;
using Viktalea.Domain.Entities;
using Viktalea.Infraestructure.Persistence;

namespace Viktalea.Infraestructure.Repositories
{
    internal class UnitOfWork(ViktaleaContext context) : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly ViktaleaContext _context = context;

        private IClientRepository _clientRepository;
        public IClientRepository ClientRepository => _clientRepository ??= new ClientRepository(_context);
        public ViktaleaContext DinetDbContext => _context;
        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Err");
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            _repositories ??= [];

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IBaseRepository<TEntity>)_repositories[type];
        }
    }
}
