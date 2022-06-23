using Kozmos.WebAPI.Data.Model;
using Kozmos.WebAPI.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Kozmos.WebAPI.Data.Services
{
    public class CategoryServices
    {

        private KozmosContext _context;
        public CategoryServices(KozmosContext context)
        {
            _context = context;

        }

        public List<CategoryVM> getAllCategoriesService()
        {
            var _list = _context.Categories.Select(a => new CategoryVM
            {
                CategoryId = a.CategoryId,
                CategoryName = a.CategoryName,
                Products = a.Products.Select(p => p.ProductName).ToList()
                
            }).ToList();

            return _list;
        }

        public CategoryWithProductsVM getCategoryByIdService(int id)
        {
            var category = _context.Categories.Where(c => c.CategoryId == id).Select(a => new CategoryWithProductsVM
            {
                CategoryId=a.CategoryId,
                CategoryName=a.CategoryName,
                Products = a.Products
            }).FirstOrDefault();

            return category;
        }

        public void addCategoryService(CategoryAddVM category)
        {
            var newCat = new Category
            {
                CategoryName = category.CategoryName
            };
           
            _context.Categories.Add(newCat);
            _context.SaveChanges();
        }

        public void deleteCategoryService(int categoryId)
        {
            var cat = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (cat != null)
            {
                _context.Categories.Remove(cat);
                _context.SaveChanges();

            }
        }
    }
}
