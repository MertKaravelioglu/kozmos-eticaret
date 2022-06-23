using Kozmos.WebAPI.Data.Model;
using Kozmos.WebAPI.Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kozmos.WebAPI.Data.Services
{
    public class CheckoutService
    {
        private KozmosContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CheckoutService(KozmosContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        public async Task<bool> CreateCheckoutService(List<BasketItem> basketItems, decimal totalPrice)
        {

            var checkout = new Checkout
            {

                ApplicationUserId = _context.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                TotalPrice = totalPrice,
                DeliveryDate = System.DateTime.Now.AddDays(3),
                BasketItems = new List<BasketItem>()
            };

            try
            {

                await _context.Checkouts.AddAsync(checkout);
                

                

                foreach (var item in basketItems)
                {
                    var basketItem = new BasketItem
                    {
                        Amount = item.Amount,
                        ProductId = item.ProductId,
                        CheckoutId = checkout.Id

                    };
                    await _context.BasketItems.AddAsync(basketItem);
                    
                    checkout.BasketItems.Add(basketItem);

                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }


        public async Task<List<CheckoutVM>> GetCheckoutsByIdService()
        {
            var userId = _context.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var checkoutList = _context.Checkouts.Where(p => p.ApplicationUserId == userId).Select(a => new CheckoutVM
            {

                BasketItems = a.BasketItems,
                DeliveryDate = a.DeliveryDate,
                TotalPrice = a.TotalPrice


            });

            return checkoutList.ToList();

        }

    }
}
