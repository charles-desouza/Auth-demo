using AuthApiKey.Data;
using AuthApiKey.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApiKey.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly AuthApiKeyContext _apiKeyContext;

        public UserLoginService(AuthApiKeyContext apiKeyContext)
        {
            _apiKeyContext = apiKeyContext;
        }
        public async Task<UserLogin> Login(string key){
            var login = _apiKeyContext.UserLogins.FirstOrDefault(x=>x.ApiKey == key);

            return await Task.FromResult(login);
        }
    }
}