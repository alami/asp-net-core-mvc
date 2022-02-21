using Microsoft.AspNetCore.Identity;

namespace asp_net_core_mvc.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
