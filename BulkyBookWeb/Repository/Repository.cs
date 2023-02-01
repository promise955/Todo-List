using BulkyBookWeb.Data;
using BulkyBookWeb.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BulkyBookWeb.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> dbset;

        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
            //throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;

            return query.ToList();
            //throw new NotImplementedException();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;

            query.Where(filter);

            return query.FirstOrDefault();
            //throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
            //throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange();
            // throw new NotImplementedException();
        }
    }
}
