using AuthApiKey.Model;

namespace AuthApiKey.Data
{
    public class AuthApiKeyContext: DbContext
    {
        public AuthApiKeyContext(DbContextOptions<AuthApiKeyContext> options)
            : base(options)
        {
        }


        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
    }
}