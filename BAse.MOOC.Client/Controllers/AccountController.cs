using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BAse.MOOC.Client.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace BAse.MOOC.Client.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string returnUrl = "") =>
            View(new LoginViewModel { ReturnUrl = returnUrl });

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email == "correct@mail.com" &&
                    model.Password == "correctpassword")
                {
                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(new[] {
                                new Claim(ClaimTypes.Name, "Correct Person"),
                                new Claim(ClaimTypes.Email, "correct@mail.com")
                            },
                            CookieAuthenticationDefaults.AuthenticationScheme)));

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Can't login! Wrong email or password.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}