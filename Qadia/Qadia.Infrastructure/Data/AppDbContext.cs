using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Qadia.Infrastructure.Data.Identity;

namespace Qadia.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Lawsuit> Lawsuits { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity => { entity.ToTable("Users"); });
            builder.Entity<Role>(entity => { entity.ToTable("Roles"); });
            builder.Entity<IdentityUserRole<Guid>>(entity => { entity.ToTable("UserRoles"); });
            builder.Entity<IdentityUserClaim<Guid>>(entity => { entity.ToTable("UserClaims"); });
            builder.Entity<IdentityUserLogin<Guid>>(entity => { entity.ToTable("UserLogins"); });
            builder.Entity<IdentityRoleClaim<Guid>>(entity => { entity.ToTable("RoleClaims"); });
            builder.Entity<IdentityUserToken<Guid>>(entity => { entity.ToTable("UserTokens"); });


            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
