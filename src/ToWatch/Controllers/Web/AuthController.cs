using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToWatch.Models;
using ToWatch.ViewModels;

namespace ToWatch.Controllers.Web
{
    public class AuthController : Controller
    {
        private SignInManager<AppUser> signInManager;

        public AuthController(SignInManager<AppUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "App");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

                if (signInResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Index", "App");
                    }

                    return Redirect(returnUrl);
                }
                ModelState.AddModelError("", "Username or password is incorrect");
            }

            return RedirectToAction("Index", "App");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "App");
        }
    }
}
