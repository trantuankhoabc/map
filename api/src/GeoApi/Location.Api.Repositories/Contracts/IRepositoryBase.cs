using System.Linq.Expressions;

namespace Location.Api.Repositories.Contracts;

public interface IRepositoryBase<T>
{
    IQueryable<T>
        FindAll(bool trackChanges); //fetches all records as a query object, track Changes: check whether to track changes or not

    IQueryable<T>
        FindByCondition(Expression<Func<T, bool>> expression,
            bool trackChanges); //fetches the records as a query object based on the given condition

    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}