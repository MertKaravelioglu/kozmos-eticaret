using Kozmos.WebAPI.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kozmos.WebAPI.Data
{
    public class Seed
    {
        

        public static async Task SeedData(KozmosContext ctx)
        {
            if (ctx.Products.Any() && ctx.Categories.Any()) return;
            var categories = new List<Category>
            {
                new Category
                {
                    CategoryName = "Plak"
                },
                new Category
                {
                    CategoryName = "Tablo"
                },
                new Category
                {
                    CategoryName = "Giyim"
                },
                new Category
                {
                    CategoryName = "Fotoğraf Makinesi"
                },
                new Category
                {
                    CategoryName = "Pikap"
                },
            };

            var products = new List<Product>
            {
                new Product {
                    ProductName = "Ion Mustang Lp 4-İn-1 Pikap Kırmızı",
                    ProductImage ="pikap.png",
                    PriceWithoutDiscount = 3199,
                    PriceWithDiscount = 3000,
                    CategoryId = 5,
                    ProductDescription = "Kırmızı Mustang Pikap",
                    Stock = 255,
                    YoutubeUrl = "http://youtube.com/kozmospikap",
                    IsFeatured = FeaturedType.Featured,
                    
                },
                new Product {
                    ProductName = "Canon Fotoğraf Makinesi",
                    ProductImage ="fotografmakinesi.png",
                    PriceWithoutDiscount = 2200,
                    PriceWithDiscount = 1180,
                    CategoryId = 4,
                    ProductDescription = "Profesyonel fotoğraf makinesi",
                    Stock = 50,
                    YoutubeUrl = "http://youtube.com/kozmosfotografmakinesi",
                    IsFeatured = FeaturedType.Featured,
                },
                new Product {
                    ProductName = "Çiçekli Elbise",
                    ProductImage ="ciceklielbise.png",
                    PriceWithoutDiscount = 200,
                    PriceWithDiscount = 150,
                    CategoryId = 3,
                    ProductDescription = "Bahar kadın çiçekli elbise",
                    Stock = 120,
                    YoutubeUrl = "http://youtube.com/kozmosciceklielbise",
                    IsFeatured = FeaturedType.NotFeatured,
                },
            };

            if (!ctx.SiteInfo.Any())
            {
                var siteInfo = new SiteInfo
                {
                    SiteName = "Kozmos E-Ticaret Çözümler",
                    Description = "Açıklama Giriniz",
                    PhoneNumber = "03313313131",
                    FacebookUrl = "https://facebook.com",
                    InstagramUrl = "https://instagram.com",
                    LinkedinUrl = "https://linkedin.com"

                };
                await ctx.SiteInfo.AddAsync(siteInfo);
                await ctx.SaveChangesAsync();
            }
            
           

            await ctx.Products.AddRangeAsync(products);
            await ctx.Categories.AddRangeAsync(categories);
            
            await ctx.SaveChangesAsync();
        }
    }
}
