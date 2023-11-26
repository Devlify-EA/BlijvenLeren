namespace BL.Api.Authentication
{
    public interface IJwtManager
    {
        string Authenticate(string userName, string password);
    }
}
