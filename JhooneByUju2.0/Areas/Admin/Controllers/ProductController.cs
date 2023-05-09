using JhooneByUju.DataAccess.Repository.IRepository;
using JhooneByUju.Models;
using Microsoft.AspNetCore.Mvc;

namespace JhooneByUju2._0.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Product.GetAll().ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                TempData["success"] = "Product created";
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

            Product? queriedProduct = _unitOfWork.Product.Get(u => u.Id == id);

            if (queriedProduct == null)
            {
                return NotFound();

            }
            return View(queriedProduct);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "Product updated";
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

            Product? queriedProduct = _unitOfWork.Product.Get(u => u.Id == id);

            if (queriedProduct == null)
            {
                return NotFound();

            }
            return View(queriedProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? product = _unitOfWork.Product.Get(u => u.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted";
            return RedirectToAction("Index");

        }
    }
}
