using Geo.Api.Entities.Entities;
using Geo.Api.Repositories.Abstract;
using Geo.Api.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq.Expressions;
using System.Transactions;

namespace Geo.Api.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IConfiguration _configuration;
        private readonly CityDbContext _db;

        public GenericRepository(IConfiguration configuration, CityDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        public bool Activate(T item)
        {
            item.IsActive = true;
            return Save();
        }

        public bool ActivateAll()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var inactive = _db.Set<T>().Where(x => !x.IsActive).ToList();
                    foreach (T item in inactive)
                    {
                        item.IsActive = true;
                    }
                    Save();
                    ts.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Add(T item)
        {
            _db.Set<T>().Add(item);
            return Save();
        }

        public bool Add(List<T> item)
        {
            _db.Set<T>().AddRange(item);
            return Save();
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetByDefault(Expression<Func<T, bool>> exp)
        {
            try
            {
                return _db.Set<T>().Where(exp).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public List<T> GetBySQLQuery(string attribute, string comparisionOperator, string input)
        {
            try
            {
                //string connectionString = _configuration.GetConnectionString("City");
                //DataTable table = new DataTable();
                //NpgsqlDataReader reader;
                //using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                //{
                //    connection.Open();
                //    using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM public.buildings WHERE @attributeParam = @inputParam", connection))
                //    {
                //        command.Parameters.AddWithValue("@attributeParam", attribute);
                //        command.Parameters.AddWithValue("@inputParam", input);
                //        reader = command.ExecuteReader();
                //        table.Load(reader);

                //        reader.Close();
                //        connection.Close();
                //    }
                //    var result = table.Rows.OfType<T>().ToList();
                //    return result;
                //}

                //TODO: Fix the SQL injection vulnerability
                List<T> result = _db.Set<T>().FromSqlRaw($"SELECT * FROM public.buildings WHERE {attribute} {comparisionOperator} {input}").ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetDefault(Expression<Func<T, bool>> exp)
        {
            try
            {
                T result = _db.Set<T>().FirstOrDefault(exp);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(T item)
        {
            item.IsActive = false;
            return Save();
        }

        public bool Remove(List<T> items)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (T item in items)
                        Remove(item);

                    ts.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(T item)
        {
            _db.Set<T>().Update(item);
            return Save();
        }
    }
}
