using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Thrifty.Models;
using Thrifty.Repository;

namespace Thrifty.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository = null;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> AllProduct()
        {
            var data = await _productRepository.AllProduct();           
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> SearchProduct(object sender, EventArgs e)
        {
            string searchString = Request.Form["searchBox"];
            var data = await _productRepository.SearchProduct(searchString);
            return View(data);
        }

        public async Task<IActionResult> Men()
        {
            var data = await _productRepository.Men();
            return View(data);
        }

        public async Task<IActionResult> Women()
        {
            var data = await _productRepository.Women();
            return View(data);
        }

        public async Task<IActionResult> Kids()
        {
            var data = await _productRepository.Kids();
            return View(data);
        }

        public async Task<IActionResult> Others()
        {
            var data = await _productRepository.Others();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetail(int? id)
        {
            var data = await _productRepository.ProductById(id.Value);          
            return View(data);
        }
    }
}
