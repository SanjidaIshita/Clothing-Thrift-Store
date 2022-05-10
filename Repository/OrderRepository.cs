using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thrifty.Areas.Identity.Data;
using Thrifty.Data;
using Thrifty.Models;

namespace Thrifty.Repository
{
    public class OrderRepository
    {
        private readonly ThriftyDataContext _context = null;

        public OrderRepository(ThriftyDataContext context, IConfiguration configuration)
        {
            _context = context;
        }

        public async Task<ProductModel> AddCart(int? id)
        {            
            var product = await _context.Product.Where(x => x.pId == id).FirstOrDefaultAsync();
            if (product != null)
            {
                var productDetails = new ProductModel()
                {
                    pId = product.pId,
                    pName = product.pName,
                    pSection = product.pSection,
                    pType = product.pType,
                    pFabric = product.pFabric,
                    pSize = product.pSize,
                    pColor = product.pColor,
                    pFashion = product.pFashion,
                    pCondition = product.pCondition,
                    pQuantity =product.pQuantity,
                    pImage = product.pImage,
                    pPrice = product.pPrice
                };
                return productDetails;
            }
            return null;
        }

        public async Task<ProductModel> ConfirmOrder(int? id)
        {
            var product = await _context.Product.Where(x => x.pId == id).FirstOrDefaultAsync();
            if (product != null)
            {
                var productDetails = new ProductModel()
                {
                    pId = product.pId,
                    pName = product.pName,
                    pSection = product.pSection,
                    pType = product.pType,
                    pFabric = product.pFabric,
                    pSize = product.pSize,
                    pColor = product.pColor,
                    pFashion = product.pFashion,
                    pCondition = product.pCondition,
                    pQuantity = product.pQuantity,
                    pImage = product.pImage,
                    pPrice = product.pPrice
                };
                return productDetails;
            }
            return null;
        }

        public async Task<int> PlaceOrder(PaymentModel model)
        {
            var newPayment = new Payment()
            {
                PaymentId = model.PaymentId,
                ProductId = model.ProductId,
                UserName = model.UserName,
                Address = model.Address,
                Email = model.Email,
                PhoneNo = model.PhoneNo,
                PaymentMethod = model.PaymentMethod,
                PaymentStatus = model.PaymentStatus,
                PaymentDate = DateTime.Now
            };            
            await _context.Payment.AddAsync(newPayment);
            await _context.SaveChangesAsync();
            return newPayment.PaymentId;
        }
    }
}
