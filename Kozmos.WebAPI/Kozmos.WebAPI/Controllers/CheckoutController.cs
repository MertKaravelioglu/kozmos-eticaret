using Kozmos.WebAPI.Data.Model;
using Kozmos.WebAPI.Data.Services;
using Kozmos.WebAPI.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kozmos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly CheckoutService _checkoutService;
        public CheckoutController(CheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateCheckoutController(Checkout checkout)
        {
            bool response = await _checkoutService.CreateCheckoutService(checkout.BasketItems, checkout.TotalPrice);

            if (response) return Ok("Checkout successfully added.");
            return BadRequest("Bir şeyler ters gitti");
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetCheckoutsByIdController()
        {
            List<CheckoutVM> checkouts = await _checkoutService.GetCheckoutsByIdService();
            return Ok(checkouts);
        }
    }
}
