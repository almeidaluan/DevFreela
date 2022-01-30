namespace DevFreela.Core.service
{
    public interface IAuthService
    {
         string GenerateJwtToken(string email, string role);
    }
}