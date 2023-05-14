using JhooneByUju.DataAccess.Repository.IRepository;
using JhooneByUju.Models;
using JhooneByUju.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Timers;

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
        public IActionResult Upsert(int? id)
        {
            
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()

                }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                //create 
                return View(productVM);
            }
            else
            {
                //update 
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }            
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()

                });               

                return View(productVM);
            }            

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
