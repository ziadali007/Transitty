using Domain.Contracts;
using Domain.Models;
using Persistence.Repositories;
using Presistence.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TransityDbContext _context;
        private readonly ConcurrentDictionary<Type, object> _repositories;

        public UnitOfWork(TransityDbContext context)
        {
            _context = context;
            _repositories = new ConcurrentDictionary<Type, object>();
        }
        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return (IGenericRepository<T>)_repositories.GetOrAdd(typeof(T), _ => new GenericRepository<T>(_context));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
