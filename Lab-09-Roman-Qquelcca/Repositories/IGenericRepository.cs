using System.Linq.Expressions;

namespace Lab_09_Roman_Qquelcca.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(object id);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate); // CORREGIDO
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}