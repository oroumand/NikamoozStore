using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NikamoozStore.Core.Contracts.Products;
using NikamoozStore.Core.Domain.Carts;
using NikamoozStore.Core.Domain.Products;
using NikamoozStore.EndPoints.WebUI.Infrastructures;
using NikamoozStore.EndPoints.WebUI.Models.Carts;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NikamoozStore.EndPoints.WebUI.Controllers
{
    public class CartController : Controller
    {
        private ProductRepository repository;
        private Cart _cart;

        public CartController(ProductRepository repo,Cart cart)
        {
            repository = repo;
            _cart = cart;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = _cart,
                ReturnUrl = returnUrl
            });

        }
        [HttpPost]
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Find(productId);
            if (product != null)
            {
                _cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productId,
        string returnUrl)
        {
            Product product = repository.Find(productId);
            if (product != null)
            {
                _cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }      
    }
}
