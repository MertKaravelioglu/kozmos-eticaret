using System;
using System.Collections.Generic;

namespace Kozmos.WebAPI.Data.Model
{
    public class Checkout
    {
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public string? ApplicationUserId { get; set; }

        public List<BasketItem> BasketItems { get; set; }
    }
}
