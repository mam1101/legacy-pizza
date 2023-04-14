using Microsoft.EntityFrameworkCore;
using Pizza.Store.Core.Interfaces;
using Pizza.Store.Migrations;

namespace Pizza.Store.Infrastructure.Data.Repositories;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly PizzaContext _dbContext;

    public Repository(PizzaContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual T GetById(int id)
    {
        return _dbContext.Set<T>().Find(id);
    }

    public virtual IEnumerable<T> List()
    {
        return _dbContext.Set<T>().AsEnumerable();
    }

    public virtual IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        return _dbContext.Set<T>()
            .Where(predicate)
            .AsEnumerable();
    }

    public void Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        _dbContext.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        _dbContext.SaveChanges();
    }
}