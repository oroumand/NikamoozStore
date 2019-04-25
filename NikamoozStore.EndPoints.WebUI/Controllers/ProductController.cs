using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NikamoozStore.Core.Contracts.Products;
using NikamoozStore.EndPoints.WebUI.Models.Products;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NikamoozStore.EndPoints.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;

        public ProductController(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult List(string category,int pageNumber = 1)
        {
            var model = new ProductListViewModel
            {
                Products = productRepository.GetProducts(category,2, pageNumber),
                PagingInfo = new Models.Commons.PagingInfo
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = 2,
                    TotalItems = productRepository.TotalCount(category)
                },
                CurrentCategory = category

            };
            return View(model);
        }
    }
}
