using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models;
using System.Linq.Expressions;
using Presistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly TransityDbContext _context;
        public GenericRepository(TransityDbContext context) 
        {
            _context = context;      
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T>? query = _context.Set<T>().AsNoTracking();

            if (typeof(T) == typeof(Route))
            {
                query = _context.Routes
                                .Include(r => r.BusesStop)
                                .Include(r => r.Trips)
                                .Include(r => r.Buses)
                                .AsNoTracking() as IQueryable<T>;
            }
            else if (typeof(T) == typeof(Bus))
            {
                query = _context.Buses
                                .Include(b => b.Route)
                                .Include(b => b.Trips)
                                .Include(b => b.StopTimings)
                                .AsNoTracking() as IQueryable<T>;
            }
            else if (typeof(T) == typeof(Trip))
            {
                query = _context.Trips
                                .Include(t => t.Bus)
                                .Include(t => t.Route)
                                .Include(t => t.Driver)
                                .Include(t => t.Conductor)
                                .AsNoTracking() as IQueryable<T>;
            }
            else if (typeof(T) == typeof(Employee))
            {
                query = _context.Employees
                                .Include(e => e.Schedules)
                                .Include(e => e.TripsAsDriver)
                                .Include(e => e.TripsAsConductor)
                                .AsNoTracking() as IQueryable<T>;
            }

            return await query!.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            if (typeof(T) == typeof(Route))
            {
                return await _context.Routes
                   .Include(r => r.BusesStop)
                   .Include(r => r.Trips)
                   .Include(r => r.Buses)
                   .AsNoTracking()
                   .FirstOrDefaultAsync(r => r.RouteId == id) as T;
            }
            else if (typeof(T) == typeof(Bus))
            {
                return await _context.Buses
                   .Include(b => b.Route)
                   .Include(b => b.Trips)
                   .Include(b => b.StopTimings)
                   .AsNoTracking()
                   .FirstOrDefaultAsync(b => b.BusId == id) as T;
            }
            else if (typeof(T) == typeof(Trip))
            {
                return await _context.Trips
                   .Include(t => t.Bus)
                   .Include(t => t.Route)
                   .Include(t => t.Driver)
                   .Include(t => t.Conductor)
                   .AsNoTracking()
                   .FirstOrDefaultAsync(t => t.TripId == id) as T;
            }
            else if (typeof(T) == typeof(Employee))
            {
                return await _context.Employees
                   .Include(e => e.Schedules)
                   .Include(e => e.TripsAsDriver)
                   .Include(e => e.TripsAsConductor)
                   .AsNoTracking()
                   .FirstOrDefaultAsync(e => e.EmployeeId == id) as T;
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        
    }
}
