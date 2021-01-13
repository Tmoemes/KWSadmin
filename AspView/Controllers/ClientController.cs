using KWSAdmin.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;

namespace AspView.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public ClientController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult AddClient()
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddClient(AspView.Models.CientViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            new Client().AddClient(new Client(model.FName, model.LName, model.Phone, model.EMail, model.Adres));
            return RedirectToAction("Index", "Home");
        }


        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
        }


    }
}
