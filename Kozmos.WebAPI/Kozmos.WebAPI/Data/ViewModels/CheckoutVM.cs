using Kozmos.WebAPI.Data.Model;
using System;
using System.Collections.Generic;

namespace Kozmos.WebAPI.Data.ViewModels
{
    public class CheckoutVM
    {
        
        public DateTime DeliveryDate { get; set; }
        public decimal TotalPrice { get; set; }

        public List<BasketItem> BasketItems { get; set; }
    }
}
