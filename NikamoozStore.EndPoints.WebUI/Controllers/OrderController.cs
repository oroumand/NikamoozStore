using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NikamoozStore.Core.Contracts.Orders;
using NikamoozStore.Core.Domain.Carts;
using NikamoozStore.Core.Domain.Orders;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NikamoozStore.EndPoints.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private OrderRepository repository;
        private Cart cart;
        public OrderController(OrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }
        public ViewResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                //TempData["OrderId"] = order.OrderID;
                //TempData["Price"] = order.Lines.Sum(c => c.Product.Price * c.Quantity);
                return RedirectToAction(nameof(Completed),new { Id = order.OrderID});
            }
            else
            {
                return View(order);
            }
        }
        public IActionResult Completed(int id)
        {
            var order = repository.Find(id);
            if(order ==  null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}
