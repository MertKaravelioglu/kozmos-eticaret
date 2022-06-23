using Kozmos.WebAPI.Data.Model;
using Kozmos.WebAPI.Data.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kozmos.WebAPI.Data.Services
{
    public class ProductsServices
    {
        private KozmosContext _context;
        public static IWebHostEnvironment _webHostEnvironment;
        public ProductsServices(KozmosContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }

        public List<ProductWithCategoryNameVM> getAllProductsService()
        {
            var productList = _context.Products.Select(a => new ProductWithCategoryNameVM
            {

                CategoryName = a.Category.CategoryName,
                PriceWithDiscount = a.PriceWithDiscount,
                PriceWithoutDiscount = a.PriceWithoutDiscount,
                ProductDescription = a.ProductDescription,
                ProductName = a.ProductName,
                ProductId = a.ProductId,
                ProductImage = a.ProductImage,
                Stock = a.Stock,
                YoutubeUrl = a.YoutubeUrl,
                IsFeatured = a.IsFeatured
                

            });

            return productList.ToList();
        }

        public ProductWithCategoryNameVM getProductByIdService(int prodId)
        {
            var product = _context.Products.Where(a => a.ProductId == prodId).Select(a => new ProductWithCategoryNameVM
            {
                CategoryName = a.Category.CategoryName,
                ProductDescription = a.ProductDescription,
                PriceWithDiscount = a.PriceWithDiscount,
                PriceWithoutDiscount = a.PriceWithoutDiscount,
                ProductId = a.ProductId,
                ProductImage = a.ProductImage,
                ProductName = a.ProductName,
                Stock = a.Stock,
                YoutubeUrl = a.YoutubeUrl,
                IsFeatured = a.IsFeatured
            }).FirstOrDefault();

            return product;
        }

        public void createProductService(ProductVM prod)
        {
            var product = new Product
            {
                CategoryId = prod.CategoryId,
                ProductName = prod.ProductName,
                PriceWithDiscount = prod.PriceWithDiscount,
                PriceWithoutDiscount = prod.PriceWithoutDiscount,
                ProductImage = prod.ProductImage,
                ProductDescription = prod.ProductDescription,
                Stock = prod.Stock,
                YoutubeUrl = prod.YoutubeUrl,
                IsFeatured = prod.IsFeatured




            };
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public async Task<FileUploadVM>  UploadImageService(IFormFile file, int id)
        {
            try
            {
                if (file.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var filePath = Guid.NewGuid() + file.FileName;
                    var ImageUrl = "http://kozmosapi-001-site1.itempurl.com/uploads/" + filePath;
                    using (FileStream fileStream = System.IO.File.Create(path + filePath))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();

                        var prod =await _context.Products.FindAsync(id);

                        prod.ProductImage = ImageUrl;
                        await _context.SaveChangesAsync();

                        return new FileUploadVM($"Dosya yüklendi isim: {filePath}", true);
                        
                        
                    }
                }
                else
                {
                    return  new FileUploadVM("Dosya yüklenemedi", false);
                }
            }
            catch (Exception ex)
            {

                return  new FileUploadVM(ex.Message, false);
            }
        }

        private void Ok(string v)
        {
            throw new NotImplementedException();
        }

        public void deleteProductService(int prodId)
        {
            var _product = _context.Products.FirstOrDefault(a => a.ProductId == prodId);
            if (_product != null) 
            {
                _context.Products.Remove(_product);
                _context.SaveChanges();
            }
        }

        public async Task<bool> updateProduct(int Id, UpdateProductViewModel vm)
        {
            var product = await _context.Products.FindAsync(Id);

            if(product != null)
            {
                product.YoutubeUrl = vm.YoutubeUrl;
                product.ProductImage = vm.ProductImage;
                product.ProductDescription = vm.ProductDescription;
                product.Stock = vm.Stock;
                product.CategoryId = vm.CategoryId;
                product.PriceWithDiscount = vm.PriceWithDiscount;
                product.PriceWithoutDiscount = vm.PriceWithoutDiscount;
                product.ProductName = vm.ProductName;
                product.IsFeatured = vm.IsFeatured;

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ChangeFeaturedStateService(int Id)
        {
            var product = await _context.Products.FindAsync(Id);

            if (product != null)
            {
                
                product.IsFeatured= product.IsFeatured.Equals(FeaturedType.Featured) ? FeaturedType.NotFeatured : FeaturedType.Featured;

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<ProductWithCategoryNameVM>> SearchProductByNameService(string input)
        {
            var productList = await _context.Products.ToListAsync();
            input = input.ToLower();

            if (!string.IsNullOrEmpty(input))
            {
                productList = productList.Where(x => x.ProductName.ToLower().Contains(input)).ToList();
            }

            var searchedList = new List<ProductWithCategoryNameVM>();

            foreach (var a in productList)
            {
                var cat = await _context.Categories.FindAsync(a.CategoryId);
                searchedList.Add( new ProductWithCategoryNameVM
                {
                    CategoryName = cat.CategoryName,
                    ProductDescription = a.ProductDescription,
                    PriceWithDiscount = a.PriceWithDiscount,
                    PriceWithoutDiscount = a.PriceWithoutDiscount,
                    ProductId = a.ProductId,
                    ProductImage = a.ProductImage,
                    ProductName = a.ProductName,
                    Stock = a.Stock,
                    YoutubeUrl = a.YoutubeUrl,
                    IsFeatured = a.IsFeatured
                });
            }

            return searchedList;
        }

    }
}
