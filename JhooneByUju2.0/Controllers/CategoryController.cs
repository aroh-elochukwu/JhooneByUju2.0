using JhooneByUju.DataAccess.Data;
using JhooneByUju.Models;
using Microsoft.AspNetCore.Mvc;

namespace JhooneByUju2._0.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List <Category> categoriesList = _db.Categories.ToList();

            return View(categoriesList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            //if (category.Name == category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The Display Order cannot exactly match the Name");
            //}

            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category created";
                return RedirectToAction("Index");
            } 
            
            return View();

            
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Category queriedCategory = _db.Categories.Find(id);

            if (queriedCategory == null)
            {
                return NotFound();

            }
            return View(queriedCategory);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {            
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category updated";
                return RedirectToAction("Index");
            }

            return View();


        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Category? queriedCategory = _db.Categories.Find(id);

            if (queriedCategory == null)
            {
                return NotFound();

            }
            return View(queriedCategory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category deleted";
            return RedirectToAction("Index");

        }
    }
}
