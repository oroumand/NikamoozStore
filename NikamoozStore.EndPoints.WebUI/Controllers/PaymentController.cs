using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NikamoozStore.Core.Contracts.Orders;
using NikamoozStore.Core.Contracts.Payments;
using NikamoozStore.Core.Domain.Payments;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NikamoozStore.EndPoints.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly OrderRepository orderRepository;
        private readonly PaymentService payment;
        private readonly IConfiguration configuration;

        public PaymentController(OrderRepository orderRepository,PaymentService payment,IConfiguration configuration )
        {
            this.orderRepository = orderRepository;
            this.payment = payment;
            this.configuration = configuration;
        }
        // GET: /<controller>/
        [HttpPost]
        public IActionResult RequestPayment(int orderId)
        {
            var order = orderRepository.Find(orderId);
            var result = payment.RequestPayment(order.Lines.Sum(c=>c.Product.Price).ToString(),"09122345677",order.OrderID.ToString(),$"Description {order.Name}");
            if (result.IsCorrect)
            {
                orderRepository.SetTransactionId(orderId, result.Token);
                return Redirect($"{configuration["PayIr:PaymentUrl"]}{result.Token}");
            }
            return View(result);
        }

        public IActionResult Verify(RequestPaymentResult result)
        {
            if (result.IsCorrect)
            {
                var verifyResult = payment.VerifyPayment(result.Token.ToString());
                if (verifyResult.IsCorrect)
                {
                    orderRepository.SetPaymentDone(verifyResult.factorNumber);
                    return View("PaymentCompelete", verifyResult);
                }


            }
            return View(result);

        }
    }
}
