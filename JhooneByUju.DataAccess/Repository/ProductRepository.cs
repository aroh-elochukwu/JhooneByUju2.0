using JhooneByUju.DataAccess.Data;
using JhooneByUju.DataAccess.Repository.IRepository;
using JhooneByUju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JhooneByUju.DataAccess.Repository
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
                
        }

        public void Update (Product product)
        {
            Product queriedProduct = _db.Products.FirstOrDefault(x => x.Id == product.Id);
            if (queriedProduct != null )
            {
                queriedProduct.Title = product.Title;
                queriedProduct.Description = product.Description;
                queriedProduct.Designer = product.Designer;
                queriedProduct.StoreCode = product.StoreCode;
                queriedProduct.CategoryId = product.CategoryId;
                queriedProduct.Price = product.Price;
                queriedProduct.ListPrice = product.ListPrice;
                queriedProduct.Price15 = product.Price15;
                if (product.ImageUrl != null )
                {
                    queriedProduct.ImageUrl = product.ImageUrl;

                }
            }            
        }
    }
}
