using NikamoozStore.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikamoozStore.Core.Contracts.Categories
{
    public interface CategoryRepository
    {
        List<Category> GetAll();
    }
}
