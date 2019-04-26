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

        public CartController(ProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });

        }
        [HttpPost]
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Find(productId);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productId,
        string returnUrl)
        {
            Product product = repository.Find(productId);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);

            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }
        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}
