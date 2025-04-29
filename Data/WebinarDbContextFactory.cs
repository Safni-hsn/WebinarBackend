using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebinarBackend.Data
{
    public class WebinarDbContextFactory : IDesignTimeDbContextFactory<WebinarDbContext>
    {
        public WebinarDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebinarDbContext>();
            optionsBuilder.UseNpgsql("Host=ep-square-salad-a5hzellr-pooler.us-east-2.aws.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_clFr57fZyoMI;Ssl Mode=Require");

            return new WebinarDbContext(optionsBuilder.Options);
        }
    }
}
