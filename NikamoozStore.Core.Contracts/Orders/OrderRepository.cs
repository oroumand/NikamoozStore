using System;
using System.Collections.Generic;
using System.Text;
using NikamoozStore.Core.Domain.Orders;

namespace NikamoozStore.Core.Contracts.Orders
{
    public interface OrderRepository
    {
        void SaveOrder(Order order);
    }
}
