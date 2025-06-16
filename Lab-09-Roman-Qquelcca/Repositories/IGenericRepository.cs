// using System.Linq.Expressions;
//
// namespace Lab_09_Roman_Qquelcca.Repositories;
//
// public interface IGenericRepository<T> where T : class
// {
//     Task<IEnumerable<T>> GetAllAsync();
//     Task<T?> GetByIdAsync(object id);
//     Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
//     Task AddAsync(T entity);
//     void Update(T entity);
//     void Delete(T entity);
//
//     // ✅ Método para incluir relaciones (e.g. .Include(x => x.Orders))
//     IQueryable<T> GetAllWithInclude(params Expression<Func<T, object>>[] includes);
// }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lab_09_Roman_Qquelcca.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        
        // Método para incluir relaciones
        IQueryable<T> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
