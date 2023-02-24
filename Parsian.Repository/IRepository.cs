using System.Linq.Expressions;
using Parsian.DomainModel.Seedworks;

namespace Parsian.Repository;

public interface IRepository<TEntity> where TEntity : IAggregateRoot
{
    void Add(TEntity entity);

    void Remove(TEntity entity);

    void Update(TEntity entity);

    Task<TEntity> GetByIdAsync(object id);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<IEnumerable<TEntity>> GetAllAsync<TProperty>
        (Expression<Func<TEntity, TProperty>> include);

    Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
}