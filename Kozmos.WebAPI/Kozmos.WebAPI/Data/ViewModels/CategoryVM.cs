using Kozmos.WebAPI.Data.Model;
using System.Collections.Generic;

namespace Kozmos.WebAPI.Data.ViewModels
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<string> Products { get; set; }
    }

    public class CategoryAddVM
    {
        public string CategoryName { get; set; }
    }

    public class CategoryWithProductsVM
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
