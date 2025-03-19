using System.Globalization;

namespace TaskManager.Contracts
{
    public record UserLoginRequest(string email, string password);
}
