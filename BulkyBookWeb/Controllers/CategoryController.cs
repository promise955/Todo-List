using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }

        public IActionResult Index()

        {
            IEnumerable<Category> objCategoriesList = _db.GetAll();

            return View(objCategoriesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {

                ModelState.AddModelError("name", "The Display Order Cannot exactly match name");

            }
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.save();
                TempData["success"] = "created successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Go back");

            }
            var category = _db.GetFirstOrDefault(u => u.Id == id);
            //Console.WriteLine(category);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            //Console.WriteLine(categoryFromDbFirst);
            //var single = _db.Categories.SingleOrDefault(u => u.Id == id);
            //Console.WriteLine(single);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)


        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "the DisplayOrder cannot exactly match the name");
            }

            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.save();
                TempData["success"] = "updated successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categories = _db.GetFirstOrDefault(u => u.Id == id);

            return View(categories);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)


        {
            var obj = _db.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.save();
            TempData["success"] = "Deleted uccessfully";
            return RedirectToAction("Index");

        }
    }
}
