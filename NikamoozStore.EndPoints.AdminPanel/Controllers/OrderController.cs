using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NikamoozStore.Core.Contracts.Orders;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NikamoozStore.EndPoints.AdminPanel.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly OrderRepository orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IActionResult NewOrders()
        {
            var result = orderRepository.Search(false);
            return View(result);
        }
        public IActionResult ViewDetail(int id)
        {
            var order = orderRepository.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        [HttpPost]
        public IActionResult Ship(int id)
        {
            var order = orderRepository.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            orderRepository.Ship(id);
            return RedirectToAction(nameof(NewOrders));
        }
    }
}
