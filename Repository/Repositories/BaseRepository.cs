using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DBContext;
using System.Linq.Expressions;

namespace Repository.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{

    private readonly ParkingManagementDbContext _context;
    public BaseRepository(ParkingManagementDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> Entity() => _context.Set<T>();
    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }
    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(x => x.IsArchived != true).Where(predicate);
    }
    public T GetById(long id)
    {
        return _context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAllEnumerable()
    {
        return _context.Set<T>().AsEnumerable();
    }

    public IQueryable<T> GetAllQueryable()
    {
        return _context.Set<T>();
    }
    public bool Any()
    {
        return _context.Set<T>().Where(w => w.IsArchived != true).Any();
    }

    public bool Any(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(w => w.IsArchived != true).Any(predicate);
    }
    public T FirstOrDefault(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(w => w.IsArchived != true).FirstOrDefault(predicate);
    }
    public T FirstOrDefault()
    {
        return _context.Set<T>().Where(w => w.IsArchived != true).FirstOrDefault();
    }


}
