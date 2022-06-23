using Kozmos.WebAPI.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kozmos.WebAPI.Data.Services
{
    public class SiteInfoServices
    {
        private KozmosContext _context;
        public SiteInfoServices(KozmosContext context)
        {
            _context = context;

        }

        public async Task<SiteInfoVM> getSiteInfoService()
        {
            var siteInfo = await _context.SiteInfo.FindAsync(1);



            return  new SiteInfoVM
            {
                Description = siteInfo.Description,
                SiteName = siteInfo.SiteName,   
                FacebookUrl = siteInfo.FacebookUrl,
                InstagramUrl = siteInfo.InstagramUrl,
                KeyWords = siteInfo.KeyWords,
                LinkedinUrl = siteInfo.LinkedinUrl,
                PhoneNumber = siteInfo.PhoneNumber 
                
            };
        }

        public async Task<bool> UpdateSiteInformationService(SiteInfoVM vm)
        {
            var siteInfo = await _context.SiteInfo.FindAsync(1);

            siteInfo.KeyWords = vm.KeyWords;
            siteInfo.LinkedinUrl = vm.LinkedinUrl;  
            siteInfo.FacebookUrl = vm.FacebookUrl;
            siteInfo.PhoneNumber= vm.PhoneNumber;
            siteInfo.SiteName = vm.SiteName;
            siteInfo.Description = vm.Description;
            siteInfo.InstagramUrl = vm.InstagramUrl;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
