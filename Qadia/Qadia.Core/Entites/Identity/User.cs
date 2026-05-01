using Microsoft.AspNetCore.Identity;

namespace Qadia.Infrastructure.Data.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string? FullName { get; set; }
    }

    public class Role : IdentityRole<Guid>
    {
        public Role() : base() { }
        public Role(string roleName) : base(roleName) { }
    }
}
