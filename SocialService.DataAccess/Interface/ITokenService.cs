using System.Threading.Tasks;

namespace SocialService.DataAccess.Interface
{
    public interface ITokenService
    {
        Task<string> GetToken(string username, string userPassword);
    }
}
