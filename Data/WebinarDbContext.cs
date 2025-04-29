using Microsoft.EntityFrameworkCore;
using WebinarBackend.Models;

namespace WebinarBackend.Data
{
    public class WebinarDbContext : DbContext
    {
        public WebinarDbContext(DbContextOptions<WebinarDbContext> options) : base(options) {}

        public DbSet<User> Users => Set<User>();
        public DbSet<Webinar> Webinars { get; set; }

    }
}
