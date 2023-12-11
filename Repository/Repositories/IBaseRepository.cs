using Entity.Models;
using System.Linq.Expressions;

namespace Repository.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    IQueryable<T> Entity();
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    T GetById(long id);
    IEnumerable<T> GetAllEnumerable();
    IQueryable<T> GetAllQueryable();
    bool Any();
    bool Any(Expression<Func<T, bool>> predicate);
    T FirstOrDefault(Expression<Func<T, bool>> predicate);
    T FirstOrDefault();
}