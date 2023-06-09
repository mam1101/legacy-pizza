using System.Linq.Expressions;

namespace Pizza.Store.Core.Interfaces;

public interface IRepository<T> where T : EntityBase
{
    T GetById(int id);
    IEnumerable<T> List();
    IEnumerable<T> List(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}

public abstract class EntityBase
{
    public int Id { get; protected set; }
}