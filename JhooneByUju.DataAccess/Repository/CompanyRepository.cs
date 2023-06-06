using JhooneByUju.DataAccess.Data;
using JhooneByUju.DataAccess.Repository.IRepository;
using JhooneByUju.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JhooneByUju.DataAccess.Repository
{
    public class CompanyRepository: Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base (db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            Company queriedCompany = _db.Companies.FirstOrDefault(x => x.Id == company.Id);

            if (queriedCompany != null)
            {
                queriedCompany.Name = company.Name;
                queriedCompany.StreetAddress = company.StreetAddress;
                queriedCompany.City = company.City;
                queriedCompany.State = company.State;
                queriedCompany.PostalCode = company.PostalCode;
                queriedCompany.PhoneNumber = company.PhoneNumber;

            }
        }
    }
}
