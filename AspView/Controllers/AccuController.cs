using AspView.Models;
using KWSAdmin.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;

namespace AspView.Controllers
{
    public class AccuController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public AccuController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult AddAccu()
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult AddAccu(AccuViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");

            new Accu().AddAccu(new Accu(model.Name, GetCurrentUserId(), model.Specs));

            return RedirectToAction("Index", "Home");
        }


        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
        }

    }
}
