using Kozmos.WebAPI.Data;
using Kozmos.WebAPI.Data.Model;
using Kozmos.WebAPI.Data.Services;
using Kozmos.WebAPI.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kozmos.WebAPI.Controllers
{
    [EnableCors]

    [Route("api/[controller]")]
    [ApiController]



    public class ProductsController : ControllerBase
    {
        public ProductsServices _productsServices;
        private readonly KozmosContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ProductsController(ProductsServices productsServices, KozmosContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _productsServices = productsServices;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]

        public IActionResult GetAllProductsController()
        {
            List<ProductWithCategoryNameVM> list = _productsServices.getAllProductsService();

            return Ok(list);
        }

        [Authorize]
        [HttpPost("addImage/{id}")]
        public async Task<ActionResult> PostImageController([FromForm] IFormFile file, int id)
        {


            var userId = _context.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            if (userRoles.Contains("Admin"))
            {
                var response = await _productsServices.UploadImageService(file, id);
                if (response.Success)
                {
                    return Ok(response.Message);
                }
                return BadRequest(response.Message);
            }
            return Unauthorized();


            
        }

        [HttpGet("{id}")]
        public IActionResult GetProductByIdController(int id)
        {


            var prod = _productsServices.getProductByIdService(id);
            return Ok(prod);


        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateProductController(ProductVM prod)
        {


            var userId = _context.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser user =   await _userManager.FindByIdAsync(userId);
            List<string> userRoles =  await  _userManager.GetRolesAsync(user) as List<string>;
            if (userRoles.Contains("Admin"))
            {
                _productsServices.createProductService(prod);
                return Ok();
            }
            return Unauthorized();




           
        }
        [Authorize]
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProductController(int id)
        {


            var userId = _context.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            if (userRoles.Contains("Admin"))
            {
                _productsServices.deleteProductService(id);
                return Ok();
            }
            return Unauthorized();

            
            
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(UpdateProductViewModel vm, int id)
        {

            var userId = _context.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            if (userRoles.Contains("Admin"))
            {
                bool result = await _productsServices.updateProduct(id, vm);
                if (result)
                {
                    return Ok("Güncelleme işlemi başarılı");
                }
                return NotFound("Güncelleme işlemi başarısız, kayıt bulunamadı");
                
            }
            return Unauthorized();


           
        }

        [Authorize]
        [HttpPut("changefeatured/{id}")]
        public async Task<ActionResult> ChangeFeaturedController(int id)
        {


            var userId = _context.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            if (userRoles.Contains("Admin"))
            {
                bool result = await _productsServices.ChangeFeaturedStateService(id);
                if (result)
                {
                    return Ok("Öne çıkarma durumu başarıyla değiştirildi");
                }
                return BadRequest("İşlem gerçekleştirilemedi");

            }
            return Unauthorized();



            
        }

        [HttpGet("search")]
        public async Task<ActionResult> SearchProductByNameController([FromQuery] string input)
        {
            var searchedList = await _productsServices.SearchProductByNameService(input);
            if (searchedList.Count > 0)
            {
                return Ok(searchedList);
            }
            else
            {
                return BadRequest("Böyle bir ürün bulunmamaktadır.");
            }
        }


    }
}
