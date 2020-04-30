using System.Threading.Tasks;
using AuthApiKey.Model;

namespace AuthApiKey.Services
{
    public interface IUserLoginService
    {
         Task<UserLogin> Login(string key);
    }
}