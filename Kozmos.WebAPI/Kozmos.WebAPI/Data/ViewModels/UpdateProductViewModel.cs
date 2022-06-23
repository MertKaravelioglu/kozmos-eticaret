using Kozmos.WebAPI.Data.Model;

namespace Kozmos.WebAPI.Data.ViewModels
{
    public class UpdateProductViewModel
    {
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal PriceWithoutDiscount { get; set; }
        public decimal? PriceWithDiscount { get; set; }
        public int Stock { get; set; }
        public string YoutubeUrl { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }

        public FeaturedType IsFeatured { get; set; }
    }
}
