using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpBasicAuth.Middleware
{
  using System;
  using System.Net;
  using System.Text;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Routing;
  using Microsoft.Extensions.Configuration;

  public class BasicAuthMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    private readonly string _realm;

    public BasicAuthMiddleware(RequestDelegate next, IConfiguration configuration, string realm)
    {
      _next = next;
      _configuration = configuration;
      _realm = realm;
    }

    public async Task Invoke(HttpContext context)
    {
      string authHeader = context.Request.Headers["Authorization"];
        
      {
        // Get the encoded username and password
        var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
        // Decode from Base64 to string
        var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
        // Split username and password
        var username = decodedUsernamePassword.Split(':', 2)[0];
        var password = decodedUsernamePassword.Split(':', 2)[1];
        // Check if login is correct
        if (IsAuthorized(username, password))
        {
          await _next.Invoke(context);
          return;
        }
      }
      // Return authentication type (causes browser to show login dialog)
      context.Response.Headers["WWW-Authenticate"] = "Basic";
      // Add realm if it is not null
      if (!string.IsNullOrWhiteSpace(_realm))
      {
        context.Response.Headers["WWW-Authenticate"] += $" realm=\"{_realm}\"";
      }
      // Return unauthorized
      context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
    }

    // Make your own implementation of this
    public bool IsAuthorized(string username, string password)
    {
      //IConfiguration config = new ConfigurationBuilder()
      //    .AddJsonFile("appsettings.json", true, true)
      //    .Build();

      var basicAuthUserName = _configuration["BasicAuth:UserName"];
      var basicAuthPassword = _configuration["BasicAuth:Password"];

      return username.Equals(basicAuthUserName, StringComparison.InvariantCultureIgnoreCase)
             && password.Equals(basicAuthPassword);
    }
  }
}