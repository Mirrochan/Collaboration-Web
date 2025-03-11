using TaskManager.Models;

namespace Infrastructure
{
    public interface IJwtProvider
    {
        string GenerateToken(UserModel user);
    }
}