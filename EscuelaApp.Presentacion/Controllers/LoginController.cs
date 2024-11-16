using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EscuelaApp.Presentacion.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [AllowAnonymous] //explicictamente permite a usuarios no autenticados puedan acceder 
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(string username, string password)
        {
            //credenciales quemadas, se deberia llamar al api y este devolvedr un objeto del usuario
            string hcUsername = "1";
            string hcPassword = "1";
            string hcFullName = "Rolando Sequeira Victor";
            string hcRole = "administrador";

            //verificar las credenciales
            if (hcUsername == username && hcPassword == password)
            {
                //crear los claims
                 var claims = new List<Claim>{
                     new Claim(ClaimTypes.Name,hcFullName),
                     new Claim(ClaimTypes.NameIdentifier,username),
                     new Claim(ClaimTypes.Role,hcRole)
                 };

                //crear la identiddad del claim
                var claimIdentity  = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //authenticar al user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Nombre de Usuario o contraseña incorrectos");
                return View("Index");
            }
            return View();
        }
    }
}
