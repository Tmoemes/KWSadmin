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
            if (!User.IsInRole("Admin")) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult AddAccu(AccuViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Index", "Home");

            new Accu().AddAccu(new Accu(model.Name, GetCurrentUserId(), model.Specs));

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccuView(int id)
        {
            var selectedAccu = new Accu().GetAccuById(id);
            if (selectedAccu != null) return View(selectedAccu);
            ModelState.AddModelError("", "Something went wrong while trying to connect to the database ");
            return RedirectToAction("Index", "Home");

        }

        public IActionResult UpdateAccu(int id)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Index", "Home");
            var selectedAccu = new Accu().GetAccuById(id);
            if (selectedAccu != null)
            {
                var model = new AccuViewModel()
                {
                    Id = id, Name = selectedAccu.Name, Specs = selectedAccu.Specs, CreatorId = selectedAccu.Creator.Id,
                    CreatorName = selectedAccu.Creator.Username
                };
                return View(model);
            }
            ModelState.AddModelError("", "Something went wrong while trying to connect to the database ");
            return RedirectToAction("AccuView",new {id = id});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAccu(AccuViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Index", "Home");

            var accu = new Accu(model.Id, model.Name,model.CreatorId,model.Specs);
            
            if (new Accu().UpdateAccu(accu))
            {
                return RedirectToAction("AccuView", new { id = model.Id });
            }

            ModelState.AddModelError("", "Something went wrong while trying to connect to the database ");
            return View(model);
        }

        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
        }

    }
}
