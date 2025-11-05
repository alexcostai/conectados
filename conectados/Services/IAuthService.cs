using conectados.Models;
using conectados.ViewModels;

namespace conectados.Services
{
    public interface IAuthService
    {
        Task<User> Register(RegisterUserDTO request);
        Task<string> Login(LoginUserDTO request);
    }
}
