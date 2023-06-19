using JhooneByUju.DataAccess.Data;
using JhooneByUju.DataAccess.Repository.IRepository;
using JhooneByUju.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JhooneByUju.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>,IOrderHeaderRepository
    {
        private ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
            
        }        

        public void Update(OrderHeader orderHeader)
        {
           _db.OrderHeaders.Update(orderHeader);
        }
    }
}
