using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ProductManagementApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly string adminUsername = "Admin";
        private readonly string adminPassword = "Admin@3731";

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username == "Admin" && password == "Admin@3731")
            {
                HttpContext.Session.SetString("Username", username);

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("Index", "Products");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }


        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Admin");
        }
    }
}
