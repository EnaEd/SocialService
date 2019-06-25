namespace SocialService.DataAccess.Interface
{
    public interface ITokenService
    {
        string GetToken(string username, string userPassword);
    }
}
