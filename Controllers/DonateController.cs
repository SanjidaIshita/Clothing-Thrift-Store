using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
    public class DonateController : Controller
    {
        private readonly ProductRepository _productRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DonateController(ProductRepository productRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult MakeDonation()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult PostProduct()
        {           
            return View();
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostProduct([Bind("pName,pSection,pType,pFabric,pSize,pColor,pFashion,pCondition,pPrice")] ProductModel productModel)
        {
            if(ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;
                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images\\Products");

                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse
                                (file.ContentDisposition).FileName.Trim('"');
                            System.Console.WriteLine(fileName);
                            var img = Path.Combine(uploads, file.FileName);
                            using (var fileStream = new FileStream(img, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                productModel.pImage = Path.Combine("images\\Products", file.FileName);
                            }
                        }
                    }
                }
                int id = await _productRepository.PostProduct(productModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(ConfirmDonation), new { isSuccess = true, donationId = id });
                }
            }
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult ConfirmDonation(bool isSuccess = false, int donationId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.DonationId = donationId;
            return View();
        }
    }
}
