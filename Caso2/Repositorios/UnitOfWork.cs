using System.Collections;
using Caso2.Interfaces;
using Caso2.Models;

namespace Caso2.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServiciosDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(ServiciosDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
                return (IGenericRepository<TEntity>)_repositories[type]!;

            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

            if (repositoryInstance != null)
            {
                _repositories.Add(type, repositoryInstance);
                return (IGenericRepository<TEntity>)repositoryInstance;
            }

            throw new Exception($"No se pudo crear una instancia del repositorio para el tipo {type}");
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}