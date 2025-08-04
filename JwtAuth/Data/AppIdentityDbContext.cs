using JwtAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuth.Data
{
  public class AppIdentityDbContext : DbContext
  {
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
    {
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
  }
}