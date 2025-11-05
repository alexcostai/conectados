using conectados.Data;
using conectados.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace conectados.Controllers
{
    public class AuthController : Controller
    {
        private readonly ConectadosDBContext _conectadosDBContext;
        public AuthController(ConectadosDBContext conectadosDBContext)
        {
            _conectadosDBContext = conectadosDBContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginUserDTO user)
        {
            //User? SearchedUser = await _conectadosDBContext.Users
            //    .Where(u => u.Email == user.Email && u.Hashed_Password)
            return View();
        }
    }
}
