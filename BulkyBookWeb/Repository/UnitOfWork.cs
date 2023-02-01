using BulkyBookWeb.Data;
using BulkyBookWeb.Repository.IRepository;

namespace BulkyBookWeb.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }

        public void save()
        {
            _db.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
