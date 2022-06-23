using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Kozmos.WebAPI.Data.Model
{
    public class ApplicationUser: IdentityUser
    {
        
        public string FullName { get; set; }
        public List<CustomerMessage> CustomerMessages { get; set; }
        public List<Checkout> Checkouts { get; set; }
    }
}
