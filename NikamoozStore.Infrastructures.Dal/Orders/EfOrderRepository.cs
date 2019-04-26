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

        public List<OrderHeader> Search(bool? Shipped)
        {
            var orders = _ctx.Orders.Where(c => !Shipped.HasValue || c.Shipped == Shipped.Value).
                Select(c => new OrderHeader
                {
                    City = c.City,
                    State = c.State,
                    Shipped = c.Shipped,
                    Line1 = c.Line1,
                    Name = c.Name,
                    OrderID = c.OrderID,
                    PaymentId = c.PaymentId,
                    TotalPrice = c.Lines.Sum(d=>d.Product.Price),
                    PaymentDate = c.PaymentDate,
                    
                }).ToList();
            return orders;
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

        public void Ship(int orderId)
        {
            var order = _ctx.Orders.Find(orderId);
            if (order != null)
            {
                order.Shipped = true;
                _ctx.SaveChanges();
            }
        }
    }
}
