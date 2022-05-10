using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Thrifty.Models;
using Thrifty.Repository;

namespace Thrifty.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeRepository _homeRepository = null;

        public HomeController(HomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _homeRepository.TopProducts();
            return View(data);
        }

        public IActionResult About()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _homeRepository.Contact(contactModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {

            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> OrderInformation()
        {
            var data = await _homeRepository.OrderInformation();
            return View(data);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> FeedbackInformation()
        {
            var data = await _homeRepository.FeedbackInformation();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
