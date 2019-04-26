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

        public void SaveOrder(Order order)
        {
            _ctx.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                _ctx.Orders.Add(order);
            }
            _ctx.SaveChanges();
        }
    }
}
