using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Thrifty.Models;
using Thrifty.Repository;

namespace Thrifty.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderRepository _orderRepository = null;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Cart(int? id)
        {
            var data = await _orderRepository.AddCart(id.Value);
            return View(data);
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> ConfirmOrder(int? id)
        {
            var data = await _orderRepository.ConfirmOrder(id.Value);
            return View(data);
        }

        [Authorize(Roles = "User")]
        public IActionResult PlaceOrder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(PaymentModel paymentModel)
        {
            if (ModelState.IsValid)
            {
                
                int id = await _orderRepository.PlaceOrder(paymentModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(Payment));
                }
            }
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult Payment()
        {
            return View();
        }
    }
}
