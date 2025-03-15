using Microsoft.AspNetCore.Identity;

namespace SpecialPrograms2Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Additional fields optional
        public string? FullName { get; set; }
    }
}