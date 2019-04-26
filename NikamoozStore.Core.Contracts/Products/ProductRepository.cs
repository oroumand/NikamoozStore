using NikamoozStore.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikamoozStore.Core.Contracts.Products
{
    public interface ProductRepository
    {
        int TotalCount(string category);
        List<Product> GetProducts(string category,int pageSize = 4, int pageNumber = 1);
        Product Find(int productId);
        void Add(Product product);
    }
}
