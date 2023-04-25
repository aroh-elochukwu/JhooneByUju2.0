using JhooneByUju2._0.Data;
using JhooneByUju2._0.Models;
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
    }
}
