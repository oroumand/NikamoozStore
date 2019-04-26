using Microsoft.EntityFrameworkCore;
using NikamoozStore.Core.Contracts.Orders;
using NikamoozStore.Core.Domain.Orders;
using NikamoozStore.Infrastructures.Dal.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikamoozStore.Infrastructures.Dal.Orders
{
    public class EfOrderRepository: OrderRepository
    {
        private readonly NikamoozStoreContext _ctx;

        public EfOrderRepository(NikamoozStoreContext ctx)
        {
            _ctx = ctx;
        }

        public Order Find(int id)
        {
            return _ctx.Orders.Include(c => c.Lines).ThenInclude(d=>d.Product).FirstOrDefault(c => c.OrderID == id);
        }

        public void SaveOrder(Order order)
        {
            _ctx.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                _ctx.Orders.Add(order);
            }
            _ctx.SaveChanges();
        }

        public void SetPaymentDone(string factorNumber)
        {
            var order = _ctx.Orders.Find(int.Parse(factorNumber));
            if (order != null)
            {
                order.PaymentDate = DateTime.Now;
                _ctx.SaveChanges();
            }
        }

        public void SetTransactionId(int orderId, string token)
        {
            var order = _ctx.Orders.Find(orderId);
            if (order != null)
            {
                order.PaymentId = token;
                _ctx.SaveChanges();
            }
        }
    }
}
