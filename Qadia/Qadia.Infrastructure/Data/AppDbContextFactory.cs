using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Qadia.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // استخدمنا المسار اللي إنت بعته بالظبط
            // لاحظ إننا شيلنا اسم الملف من الـ SetBasePath وخليناه بس يشاور على الفولدر
            string projectPath = @"D:\LawersProject\Qadia\Qadia";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json", optional: false) // تأكد إن الاسم هنا مطابق للملف فعلياً
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlite(connectionString);

            return new AppDbContext(builder.Options);
        }
    }
}
