namespace Kozmos.WebAPI.Data.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal PriceWithoutDiscount { get; set; }
        public decimal? PriceWithDiscount { get; set; }
        public int Stock { get; set; }
        public string YoutubeUrl { get; set; }
        public string ProductDescription { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
        public FeaturedType IsFeatured { get; set; }
    }



    public enum FeaturedType
    {
        Featured = 1,
        NotFeatured = 0
    }
}
