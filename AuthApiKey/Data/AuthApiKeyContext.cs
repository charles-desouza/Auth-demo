using AuthApiKey.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthApiKey.Data
{
    public class AuthApiKeyContext: DbContext
    {
        public AuthApiKeyContext(DbContextOptions<AuthApiKeyContext> options)
            : base(options)
        {
        }


        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}