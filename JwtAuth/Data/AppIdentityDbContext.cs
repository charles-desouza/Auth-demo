using JwtAuth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JwtAuth.Data
{
  public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
  {
    public AppIdentityDbContext(DbContextOptions options) : base(options)
    {
    }
  }
}