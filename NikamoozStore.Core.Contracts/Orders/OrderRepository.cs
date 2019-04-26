using System;
using System.Collections.Generic;
using System.Text;
using NikamoozStore.Core.Domain.Orders;

namespace NikamoozStore.Core.Contracts.Orders
{
    public interface OrderRepository
    {
        void SaveOrder(Order order);
        Order Find(int id);
        void SetTransactionId(int orderId, string token);
        void SetPaymentDone(string factorNumber);

        List<OrderHeader> Search(bool? Shipped);
        void Ship(int orderId);
    }
}
