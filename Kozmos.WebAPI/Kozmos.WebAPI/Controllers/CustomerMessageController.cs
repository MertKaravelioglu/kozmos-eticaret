using Kozmos.WebAPI.Data;
using Kozmos.WebAPI.Data.Model;
using Kozmos.WebAPI.Data.Services;
using Kozmos.WebAPI.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kozmos.WebAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerMessageController : ControllerBase
    {
        public ProductsServices _productsServices;
        private readonly KozmosContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CustomerMessageServices _customerMessageServices;

        public CustomerMessageController(ProductsServices productsServices, KozmosContext context, UserManager<ApplicationUser> userManager, CustomerMessageServices customerMessageServices)
        {
            _productsServices = productsServices;
            _context = context;
            _userManager = userManager;
            _customerMessageServices = customerMessageServices;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<CustomerMessageGetVM>>> GetAllCustomerMessagesController()
        {
            var userId = _context.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            if (userRoles.Contains("Admin"))
            {
                var list = await _customerMessageServices.GetAllCustomerMessagesService();
                return Ok(list);

            }
            return Unauthorized();


            
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateCustomerMessageController(CustomerMessageAddVM vm)
        {
            bool response = await _customerMessageServices.CreateUserMessage(vm);
            if (response)
            {
                return Ok("Mesajınız başarıyla oluşturuldu");
            }
            else
            {
                return BadRequest("Mesajınız oluşturulurken bir hata meydana geldi");
            };
            
        }

        [HttpPut("changeresolved/{id}")]
        [Authorize]
        public async Task<ActionResult> ChangeResolvedController(int id)
        {


            var userId = _context.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            if (userRoles.Contains("Admin"))
            {
                bool result = await _customerMessageServices.ChangeIsResolvedService(id);
                if (result)
                {
                    return Ok("Çözüme ulaşma durumu başarıyla değiştirildi");
                }
                return BadRequest("İşlem gerçekleştirilemedi");

            }
            return Unauthorized();


           
        }

    }
}
