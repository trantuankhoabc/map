using Geo.Api.Entities.Entities;
using System.Linq.Expressions;

namespace Geo.Api.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        bool Add(T item);
        bool Add(List<T> item);
        bool Update(T item);
        bool Remove(T item);
        bool Remove(List<T> item);
        List<T> GetAll();
        T GetById(int id);
        T GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetByDefault(Expression<Func<T, bool>> exp);
        bool Activate(T item);
        bool ActivateAll();
        bool Save();
        List<T> GetBySQLQuery(string attribute, string comparisionOpenrator, string input);
    }
}
