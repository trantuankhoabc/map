using Geo.Api.Entities.Entities;
using NetTopologySuite.Features;
using System.Linq.Expressions;

namespace Geo.Api.Business.Abstract;

public interface IGenericService<T> where T : BaseEntity
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
    List<T> GetIntersectingItems(FeatureCollection features);
    T GetItemFromCoordinates(double[] coordinates);
    List<T> GetBySqlQuery(string attribute, string comparisionOperator, string input);
}