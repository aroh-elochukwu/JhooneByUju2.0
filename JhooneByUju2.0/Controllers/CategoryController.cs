using JhooneByUju.DataAccess.Data;
using JhooneByUju.DataAccess.Repository.IRepository;
using JhooneByUju.Models;
using Microsoft.AspNetCore.Mvc;

namespace JhooneByUju2._0.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List <Category> categoriesList = _categoryRepo.GetAll().ToList();

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
                _categoryRepo.Add(category);
                _categoryRepo.Save();
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

            Category? queriedCategory = _categoryRepo.Get(u => u.Id == id);

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
                _categoryRepo.Update(category);
                _categoryRepo.Save();
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

            Category? queriedCategory = _categoryRepo.Get(u => u.Id == id);

            if (queriedCategory == null)
            {
                return NotFound();

            }
            return View(queriedCategory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _categoryRepo.Get(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _categoryRepo.Remove(category);
            _categoryRepo.Save();
            TempData["success"] = "Category deleted";
            return RedirectToAction("Index");

        }
    }
}
