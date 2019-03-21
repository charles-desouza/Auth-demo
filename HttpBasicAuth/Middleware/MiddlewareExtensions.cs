using Microsoft.AspNetCore.Builder;

namespace HttpBasicAuth.Middleware
{
  public static class MiddlewareExtensions
  {
    public static IApplicationBuilder UseBasicAuthentication(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<BasicAuthMiddleware>("Secured Pages");
    }
  }
}