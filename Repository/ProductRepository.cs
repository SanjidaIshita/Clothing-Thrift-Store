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
    public class ProductRepository
    {
        private readonly ThriftyDataContext _context = null;

        public ProductRepository(ThriftyDataContext context, IConfiguration configuration)
        {
            _context = context;
        }

        public async Task<int> PostProduct(ProductModel model)
        {
            var newProduct = new Products()
            {
                pId = model.pId,
                pName = model.pName,
                pSection = model.pSection,
                pType = model.pType,
                pFabric = model.pFabric,
                pSize = model.pSize,
                pColor = model.pColor,
                pFashion = model.pFashion,
                pCondition = model.pCondition,
                pQuantity = model.pQuantity,
                pPrice = model.pPrice,
                pImage = model.pImage,
                pCreatedOn = DateTime.Now
            };
            Console.WriteLine(newProduct.pImage);
            await _context.Product.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.pId;
        }

        public async Task<List<ProductModel>> AllProduct()
        {
            var products = new List<ProductModel>();
            var allproducts = await _context.Product.ToListAsync();
            if (allproducts?.Any() == true)
            {
                foreach (var product in allproducts)
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

        public async Task<List<ProductModel>> SearchProduct(string searchString)
        {
            var products = new List<ProductModel>();
            var searchProducts = await _context.Product.Where(x => (x.pType.Contains(searchString)) || (x.pFabric.Contains(searchString)) || x.pColor.Contains(searchString) || x.pFashion.Contains(searchString) || x.pCondition.Contains(searchString)).ToListAsync();
            if (searchProducts?.Any() == true)
            {
                foreach (var product in searchProducts)
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

        public async Task<List<ProductModel>> Men()
        {
            var products = new List<ProductModel>();
            var menProducts = await _context.Product.Where(x => x.pSection == "Men").ToListAsync();
            if (menProducts?.Any() == true)
            {
                foreach (var product in menProducts)
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

        public async Task<List<ProductModel>> Women()
        {
            var products = new List<ProductModel>();
            var womenProducts = await _context.Product.Where(x => x.pSection == "Women").ToListAsync();
            if (womenProducts?.Any() == true)
            {
                foreach (var product in womenProducts)
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

        public async Task<List<ProductModel>> Kids()
        {
            var products = new List<ProductModel>();
            var kidProducts = await _context.Product.Where(x => x.pSection == "Kids").ToListAsync();
            if (kidProducts?.Any() == true)
            {
                foreach (var product in kidProducts)
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

        public async Task<List<ProductModel>> Others()
        {
            var products = new List<ProductModel>();
            var otherProducts = await _context.Product.Where(x => x.pSection == "Others").ToListAsync();
            if (otherProducts?.Any() == true)
            {
                foreach (var product in otherProducts)
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

        public async Task<ProductModel> ProductById(int? id)
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
    }
}