using JhooneByUju.DataAccess.Data;
using JhooneByUju.DataAccess.Repository.IRepository;
using JhooneByUju.Models;
using JhooneByUju.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace JhooneByUju2._0.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        public IActionResult Index()
        {
            List<Company> companies = _unitOfWork.Company.GetAll().ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Company.Add(company);
                _unitOfWork.Save();
                TempData["success"] = "Company created";
                return RedirectToAction("Index");

            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null  )
            {
                return NotFound();                
            }

            Company? queriedCompany = _unitOfWork.Company.Get(u  => u.Id == id);

            if (queriedCompany == null)
            {
                return NotFound();
            }

            return View(queriedCompany);
        }

        [HttpPost]
        public IActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Company.Update(company); 
                _unitOfWork.Save();
                TempData["success"] = "Company info Updated";
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

            Company? queriedCompany = _unitOfWork.Company.Get(u => u.Id == id);

            if (queriedCompany == null)
            {
                return NotFound();

            }
            return View(queriedCompany);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Company? company = _unitOfWork.Company.Get(u => u.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            _unitOfWork.Company.Remove(company);
            _unitOfWork.Save();
            TempData["success"] = "Company deleted";
            return RedirectToAction("Index");

        }
    }
}
