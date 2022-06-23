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
    public class CategoriesController : ControllerBase
    {
        public CategoryServices _categoryServices;
        private readonly KozmosContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CategoriesController(CategoryServices categoryServices, KozmosContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _categoryServices = categoryServices;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult getAllCategoriesController()
        {
            List<CategoryVM> list = _categoryServices.getAllCategoriesService();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult getCategoryByIdController(int id)
        {
            var category = _categoryServices.getCategoryByIdService(id);
            return Ok(category);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> createCategoryController(CategoryAddVM cat)
        {


            var userId = _context.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            if (userRoles.Contains("Admin"))
            {
                if (cat == null)
                {
                    return BadRequest();
                }

                _categoryServices.addCategoryService(cat);
                return Ok();
            }
            return Unauthorized();


            
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> deleteCategoryController(int id)
        {

            var userId = _context.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            if (userRoles.Contains("Admin"))
            {
                _categoryServices.deleteCategoryService(id);
                return Ok();
            }
            return Unauthorized();



            
        }
    }
}
