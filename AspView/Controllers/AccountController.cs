using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Cache;
using System.Security.Claims;
using System.Threading.Tasks;
using AspView.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using KWSAdmin.Persistence.Interface.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using KWSAdmin.Application;
using KWSAdmin.Persistence;
using Microsoft.AspNetCore.Http;


namespace AspView.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        [Route("AccountPage")]
        public IActionResult Account()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


         [HttpPost]
         [AllowAnonymous]
         [ValidateAntiForgeryToken]
         [Route("Login")]
         public async Task<ActionResult> Login(LoginViewModel model)
         {
             if (!ModelState.IsValid) return View(model);
        
             if (User.Identity.IsAuthenticated) return RedirectToAction("Index","Home"); 
        
             Account user = KWSAdmin.Application.Account.GetByName(model.Username);
        
             //check username 
             if (user == null)
             {
                 ModelState.AddModelError("", "Username or password is incorrect.");
                 return View(model);
             }
             //check password
             var hasher = new PasswordHasher<Account>();
             if (hasher.VerifyHashedPassword(user, user.password, model.Password) == PasswordVerificationResult.Failed)
             {
                 ModelState.AddModelError("", "Username or password is incorrect.");
                 return View(model);
             }

        
             var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name,ClaimTypes.Role);

             claimsIdentity.AddClaim(new Claim(ClaimTypes.Name , model.Username));
             claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, "User"));

            var principal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                IsPersistent = true,
            };

            if (user.admin)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, "Admin"));
            };

            await HttpContext.SignOutAsync();
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(principal),authProperties);

             return RedirectToAction("Index","Home"); 
         } 


        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }

        [Authorize]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Register")]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Password == model.PasswordCheck)
            {
                var hasher = new PasswordHasher<Account>();

                Account tempAccount = new Account(new UserDto(0, model.Username, model.Password, model.IsAdmin));

                string hashedPW = hasher.HashPassword(tempAccount, model.Password);

                tempAccount.SetHashedPw(hashedPW);

                KWSAdmin.Application.Account.AddUser(tempAccount);

                return RedirectToAction("Login", new {returnUrl = "/"});
            }

            ModelState.AddModelError(nameof(model.Username),"Passwords do not match");

            return View(model);
        }
    }
}
