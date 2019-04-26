using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NikamoozStore.Core.Contracts.Categories;
using NikamoozStore.Core.Contracts.Products;
using NikamoozStore.Core.Domain.Products;
using NikamoozStore.EndPoints.AdminPanel.Models.Products;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NikamoozStore.EndPoints.AdminPanel.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly CategoryRepository categoryRepository;
        private readonly ProductRepository productRepository;

        public ProductController(CategoryRepository categoryRepository,ProductRepository productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = productRepository.GetProducts("", 100, 1);
            return View(products);
        }
        public IActionResult Add()
        {
            AddProductViewModel model = new AddProductViewModel
            {
                CategoryForDisplay = categoryRepository.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    Name = model.Name,
                    Price = model.Price,

                };
                if (model?.Image?.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        model.Image.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        product.Image = "data:image/jpeg;base64," + Convert.ToBase64String(fileBytes);
                    }
                }
                productRepository.Add(product);
                return RedirectToAction("Index");
            }
            model.CategoryForDisplay = categoryRepository.GetAll();
            return View(model);
        }
    }
}
