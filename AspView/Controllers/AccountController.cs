using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Cache;
using System.Security.Claims;
using System.Threading.Tasks;
using AspView.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using KWSAdmin.Application;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using KWSAdmin.DALFactory;
using KWSAdmin.Persistence.Interface.Interfaces;
using Microsoft.Extensions.Configuration;


namespace AspView.Controllers
{
    public class AccountController : Controller
    {
        private readonly SqlConnection _connection;
        private readonly IAccountDal _userDal = AccountFactory.GetUserDal();


        public AccountController(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("ConnectionString"));
        }


        public IActionResult Account()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account");

            
            int userid = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);

            return View(new Account(_userDal.GetById(userid,_connection)));
        }


        public IActionResult Login()
        {
            return View();
        }


         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<ActionResult> Login(LoginViewModel model)
         {
             if (!ModelState.IsValid) return View(model);
        
             if (User.Identity.IsAuthenticated) return RedirectToAction("Index","Home");

             var user = new Account(_userDal.GetByName(model.Username, _connection));

             //check username and password exist
             if (user.Username == null || user.Password == null)
             {
                 ModelState.AddModelError("", "Username or password is incorrect.");
                 return View(model);
             }

            //check password
            var hasher = new PasswordHasher<Account>();
             if (hasher.VerifyHashedPassword(user, user.Password, model.Password) == PasswordVerificationResult.Failed)
             {
                 ModelState.AddModelError("", "Username or password is incorrect.");
                 return View(model);
             }

             var claims = new List<Claim>
             {
                 new Claim(ClaimTypes.Name,user.Username),
                 new Claim(ClaimTypes.Sid, user.Id.ToString())
             };


            if (user.Admin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignOutAsync();
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

             return RedirectToAction("Index","Home"); 
         } 


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");
            if (!ModelState.IsValid) return View(model);

            if (model.Password == model.PasswordCheck)
            {
                var hasher = new PasswordHasher<Account>();

                var tempAccount = new Account(0, model.Username, model.Password, model.IsAdmin);

                var hashedPw = hasher.HashPassword(tempAccount, model.Password);

                tempAccount.SetHashedPw(hashedPw);

                KWSAdmin.Application.Account.AddUser(tempAccount,_connection);

                return RedirectToAction("Login", new {returnUrl = "/"});
            }

            ModelState.AddModelError(nameof(model.Username),"Passwords do not match");

            return View(model);
        }
    }
}
