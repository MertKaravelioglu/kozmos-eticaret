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




    public class SiteInfoController : ControllerBase
    {

        public SiteInfoServices _siteInfoServices;
        private readonly KozmosContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SiteInfoController(SiteInfoServices siteInfoServices, KozmosContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _siteInfoServices = siteInfoServices;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        
        public async Task<ActionResult> GetSiteInfoController()
        {
            var siteInfo = await _siteInfoServices.getSiteInfoService();

            return Ok(siteInfo);
        }


        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateSiteInformation(SiteInfoVM vm)
        {
            var userId = _context.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            if (userRoles.Contains("Admin"))
            {
                await _siteInfoServices.UpdateSiteInformationService(vm);

                return Ok("Güncelleme başarıyla tamamlandı.");
            }
            return Unauthorized();

            
        }
    }
}
