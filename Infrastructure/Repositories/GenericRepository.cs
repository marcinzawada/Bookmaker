using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
           return await _context.Set<T>().Where(expression).ToListAsync(cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
