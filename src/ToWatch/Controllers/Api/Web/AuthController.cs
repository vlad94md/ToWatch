using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToWatch.Models;
using ToWatch.ViewModels;
using AutoMapper;

namespace ToWatch.Controllers.Web
{
    public class AuthController : Controller
    {
        private SignInManager<AppUser> signInManager;
        private UserManager<AppUser> userManager;

        public AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
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
                var user = await userManager.FindByEmailAsync(model.Email);
                if(user == null)
                {
                    ModelState.AddModelError("", "User with that email doesnt exists");
                    return View(model);
                }
                var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, true, false);
           
                if (signInResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Index", "App");
                    }

                    return Redirect(returnUrl);
                }
                ModelState.AddModelError("", "Password is incorrect");
                return View(model);
            }

            return RedirectToAction("Index", "App");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tryGetEmail = await userManager.FindByEmailAsync(model.Email);

                if (tryGetEmail == null)
                {
                    AppUser newUser = Mapper.Map<AppUser>(model);

                    var result = await userManager.CreateAsync(newUser, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "App");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User with that email already exists");
                    return View(ModelState);
                }
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
