using Microsoft.AspNetCore.Identity;
using System;

namespace Kozmos.WebAPI.Data.Model
{
    public class ApplicationUserTokens:IdentityUserToken<string>
    {
        public DateTime ExpireDate { get; set; }
    }
}
