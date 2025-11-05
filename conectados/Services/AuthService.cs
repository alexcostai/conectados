using conectados.Models;
using conectados.Repositories;
using conectados.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace conectados.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            this._userRepository = userRepository;
            this._passwordHasher = passwordHasher;
        }
        public async Task<string> Login(LoginUserDTO request)
        {
            User? searchedUser = await this._userRepository.GetUserByEmailAsync(request.Email);
            if (searchedUser == null)
            {
                throw new InvalidOperationException("El usuario no existe.");
            }

            var verificationResult = this._passwordHasher.VerifyHashedPassword(
                searchedUser,
                searchedUser.Hashed_Password,
                request.Password
            );

            if (verificationResult != PasswordVerificationResult.Success)
            {
                throw new InvalidOperationException("Contraseña inválida.");
            }

            return "TOKEN";
        }

        public async Task<User> Register(RegisterUserDTO request)
        {
            User? userExists = await this._userRepository.GetUserByEmailAsync(request.Email);
            if (userExists != null)
            {
                throw new InvalidOperationException("El usuario ya esta registrado.");
            }

            User newUser = new()
            {
                FullName = request.Email,
                Email = request.Email,
            };

            newUser.Hashed_Password = this._passwordHasher.HashPassword(newUser, request.Password);

            await this._userRepository.AddUserAsync(newUser);

            return newUser;
        }
    }
}
