using Microsoft.AspNetCore.Identity;

namespace Employee_API.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
