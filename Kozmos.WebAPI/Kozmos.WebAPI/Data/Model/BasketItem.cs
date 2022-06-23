namespace Kozmos.WebAPI.Data.Model
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int CheckoutId { get; set; }
        public Checkout Checkout { get; set; }
    }
}
