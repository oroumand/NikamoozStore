using NikamoozStore.Core.Contracts.Categories;
using NikamoozStore.Core.Domain.Categories;
using NikamoozStore.Infrastructures.Dal.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NikamoozStore.Infrastructures.Dal.Categories
{
    public class EfCategoryRepository : CategoryRepository
    {
        private readonly NikamoozStoreContext _ctx;

        public EfCategoryRepository(NikamoozStoreContext ctx)
        {
            _ctx = ctx;
        }
        public List<Category> GetAll()
        {
            return _ctx.Categories.ToList();
        }
    }
}
