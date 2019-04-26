using Microsoft.AspNetCore.Http;
using NikamoozStore.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikamoozStore.EndPoints.AdminPanel.Models.Products
{
    public class AddProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public List<Category> CategoryForDisplay { get; set; }
    }
}
