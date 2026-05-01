using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qadia.Infrastructure.Data;
using Qadia.Infrastructure.Data.Identity;

namespace Qadia.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString));

            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<AppDbContext>();

            // 3. تسجيل الـ Repositories
            services.AddPersistence();

            // 4. تسجيل الـ Business Services
            services.AddBusinessServices();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            // هنا هنضيف الـ Repositories لاحقاً
            return services;
        }

        private static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            // هنا هنضيف الـ Services لاحقاً
            return services;
        }
    }
}
