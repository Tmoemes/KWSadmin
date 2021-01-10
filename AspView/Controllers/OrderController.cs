using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspView.Models;
using KWSAdmin.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspView.Controllers
{
    public class OrderController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public OrderController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult CreateOrder()
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");
            OrderViewModel model = new OrderViewModel {Accus = new Accu().GetAllAccus(),Clients = new Client().GetAllClients()};

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(AspView.Models.OrderViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");

            new Order(model.Accu.Id, model.Location, GetCurrentUserId(), model.Accu.Id, model.Info).AddOrder();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult OrderView(int id)
        {
            var selectedOrder = new Order().GetById(id);
            return View(selectedOrder);
        }

        public ActionResult DeleteOrder(int id)
        {
            new Order().Delete(id);
            return RedirectToAction("Index", "Home");
        }


        public IActionResult UpdateOrder(int id)
        {

            var oldOrder = new Order().GetById(id);

            OrderViewModel model = new OrderViewModel
            {
                Id = oldOrder.Id,
                Location = oldOrder.Location,
                Accu = oldOrder.Accu,
                Client = oldOrder.Client,
                Info = oldOrder.Info,
                Done = oldOrder.Done,
                Accus = new Accu().GetAllAccus(),
                Clients = new Client().GetAllClients(),

            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateOrder(OrderViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");

            var order = new Order(model.Id, model.Client, model.Location, model.Creator, model.Accu, model.Info, model.Done);//todo vreemde error bij het ophalen van creator bij alleen deze 
            new Order().Update(order);
            return RedirectToAction("OrderView", model.Id);
        }

        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
        }
    }
}
