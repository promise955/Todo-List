using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.IRepository;

namespace BulkyBookWeb.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private readonly AppDbContext _db;
        public CategoryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }



        public void save()
        {
            _db.SaveChanges();
            // throw new NotImplementedException();
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
            // throw new NotImplementedException();
        }


    }
}
