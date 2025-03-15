using Microsoft.AspNetCore.Identity;

namespace SpecialProgramsCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        // حقول إضافية اختيارية، مثال:
        public string? FullName { get; set; }

    }
}
