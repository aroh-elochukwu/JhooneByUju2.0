﻿using JhooneByUju.DataAccess.Data;
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

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            OrderHeader orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }

            }
        }

        public void UpdateStringPaymentId(int id, string sessionId, string paymentIntentId)
        {
            OrderHeader orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
            {
                orderFromDb.SessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                orderFromDb.PaymentIntentId = paymentIntentId;
                orderFromDb.PaymentDate = DateTime.Now;
            }
        }
    }
}
