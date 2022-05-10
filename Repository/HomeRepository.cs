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
    public class HomeRepository
    {
        private readonly ThriftyDataContext _context = null;

        public HomeRepository(ThriftyDataContext context, IConfiguration configuration)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> TopProducts()
        {
            var products = new List<ProductModel>();
            var topProducts = await _context.Product.OrderByDescending(x => x.pId).Take(4).ToListAsync();
            if (topProducts?.Any() == true)
            {
                foreach (var product in topProducts)
                {
                    products.Add(new ProductModel()
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
                    });
                }
            }
            return products;
        }

        public async Task<int> Contact(ContactModel model)
        {
            var contact = new Contact()
            {
                Name = model.Name,
                Email = model.Email,
                Message = model.Message
            };
            await _context.Contact.AddAsync(contact);
            await _context.SaveChangesAsync();
            return contact.Id;
        }

        public async Task<List<PaymentModel>> OrderInformation()
        {
            var orderinfo = new List<PaymentModel>();
            var payments = await _context.Payment.ToListAsync();
            if (payments?.Any() == true)
            {
                foreach (var info in payments)
                {
                    orderinfo.Add(new PaymentModel()
                    {
                        PaymentId = info.PaymentId,
                        ProductId = info.ProductId,
                        UserName = info.UserName,
                        Address = info.Address,
                        Email = info.Email,
                        PhoneNo = info.PhoneNo,
                        PaymentMethod = info.PaymentMethod,
                        PaymentDate = DateTime.Now
                    });
                }
            }
            return orderinfo;
        }

        public async Task<List<ContactModel>> FeedbackInformation()
        {
            var feedbackInfo = new List<ContactModel>();
            var feedbacks = await _context.Contact.ToListAsync();
            if (feedbacks?.Any() == true)
            {
                foreach (var info in feedbacks)
                {
                    feedbackInfo.Add(new ContactModel()
                    {
                        Id = info.Id,
                        Name = info.Name,
                        Email = info.Email,
                        Message = info.Message
                    });
                }
            }
            return feedbackInfo;
        }
    }
}
