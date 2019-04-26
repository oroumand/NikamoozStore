using Microsoft.EntityFrameworkCore;
using NikamoozStore.Core.Contracts.Products;
using NikamoozStore.Core.Domain.Products;
using NikamoozStore.Infrastructures.Dal.Commons;
using System.Collections.Generic;
using System.Linq;

namespace NikamoozStore.Infrastructures.Dal.Products
{
    public class EfProductRepository : ProductRepository
    {
        private readonly NikamoozStoreContext _ctx;

        public EfProductRepository(NikamoozStoreContext ctx)
        {
            _ctx = ctx;
        }

        public Product Find(int productId)
        {
            return _ctx.Products.Find(productId);
        }

        public List<Product> GetProducts(string category,int pageSize = 4, int pageNumber = 1)
        {
            return _ctx.Products.Where(c => string.IsNullOrWhiteSpace(category) || c.Category.CategoryName == category).Include(c => c.Category).Skip(pageSize * (pageNumber -1)).Take(pageSize).ToList();
        }

        public int TotalCount(string category)
        {
            return _ctx.Products.Count(c=>string.IsNullOrWhiteSpace(category) || c.Category.CategoryName == category);
        }
    }
}
