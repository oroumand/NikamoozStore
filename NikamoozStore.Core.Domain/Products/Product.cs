using NikamoozStore.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikamoozStore.Core.Domain.Products
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
