namespace AuthApiKey.Data
{
    public class AuthApiKeyContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
    }
}