using WebinarBackend.Models;
using BCrypt.Net;

namespace WebinarBackend.Data
{
    public static class DbSeeder
    {
        public static void Seed(WebinarDbContext db)
        {
            if (!db.Users.Any())
            {
                db.Users.AddRange(
                    new User
                    {
                        Username = "host1",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("hostpass"),
                        Role = "host"
                    },
                    new User
                    {
                        Username = "student1",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("studentpass"),
                        Role = "student"
                    }
                );
                db.SaveChanges();
            }
        }
    }
}
