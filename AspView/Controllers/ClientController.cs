using KWSAdmin.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using AspView.Models;

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
            if (!User.IsInRole("Admin")) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddClient(AspView.Models.ClientViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Index", "Home");
            if (!ModelState.IsValid) return View(model);

            new Client().AddClient(new Client(model.FirstName, model.LastName, model.Phone, model.EMail, model.Adres));
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ClientView(int id)
        {
            var client = new Client().GetClientById(id);
            if (client != null) return View(client);
            ModelState.AddModelError("", "Something went wrong while trying to connect to the database ");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult UpdateClient(int id)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Index", "Home");
            var client = new Client().GetClientById(id);
            var model = new ClientViewModel
            {
                Adres = client.Adres, LastName = client.LastName, EMail = client.EMail, Phone = client.Phone,
                id = client.Id, FirstName = client.FirstName
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateClient(ClientViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Index", "Home");
            var client = new Client(model.id,model.FirstName,model.LastName,model.Phone,model.EMail,model.Adres);

            if (new Client().UpdateClient(client)) return RedirectToAction("ClientView",new {id = model.id});
            ModelState.AddModelError("", "Something went wrong while trying to connect to the database ");
            return View(model);
        }


        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
        }


    }
}
