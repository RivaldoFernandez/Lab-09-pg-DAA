// using Lab_09_Roman_Qquelcca.Models;
// using Microsoft.EntityFrameworkCore;
// using System.Linq.Expressions;
//
// namespace Lab_09_Roman_Qquelcca.Repositories;
//
// public class GenericRepository<T> : IGenericRepository<T> where T : class
// {
//     private readonly LinQDBContext _context;
//     private readonly DbSet<T> _dbSet;
//
//     public GenericRepository(LinQDBContext context)
//     {
//         _context = context;
//         _dbSet = context.Set<T>();
//     }
//
//     public async Task<IEnumerable<T>> GetAllAsync()
//     {
//         return await _dbSet.ToListAsync();
//     }
//
//     public async Task<T?> GetByIdAsync(object id)
//     {
//         return await _dbSet.FindAsync(id);
//     }
//
//     public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
//     {
//         return await _dbSet.Where(predicate).ToListAsync();
//     }
//
//     public async Task AddAsync(T entity)
//     {
//         await _dbSet.AddAsync(entity);
//     }
//
//     public void Update(T entity)
//     {
//         _dbSet.Update(entity);
//     }
//
//     public void Delete(T entity)
//     {
//         _dbSet.Remove(entity);
//     }
//
//     // ✅ Implementación de GetAllWithInclude
//     public IQueryable<T> GetAllWithInclude(params Expression<Func<T, object>>[] includes)
//     {
//         IQueryable<T> query = _dbSet;
//
//         foreach (var include in includes)
//         {
//             query = query.Include(include);
//         }
//
//         return query;
//     }
// }


using Lab_09_Roman_Qquelcca.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lab_09_Roman_Qquelcca.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LinQDBContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(LinQDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public IQueryable<T> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
