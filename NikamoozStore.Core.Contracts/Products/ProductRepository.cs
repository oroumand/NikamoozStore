using NikamoozStore.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikamoozStore.Core.Contracts.Products
{
    public interface ProductRepository
    {
        List<Product> GetProducts(); 
    }
}
