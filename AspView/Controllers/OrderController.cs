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

            new Order(model.ClientId, model.Location, GetCurrentUserId(), model.AccuId, model.Info).AddOrder();
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
                AccuId = oldOrder.Accu.Id,
                ClientId = oldOrder.Client.Id,
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

            var oldOrder = new Order().GetById(model.Id);

            var client = new Client().GetById(model.ClientId);
            var accu = new Accu().GetById(model.AccuId);
            var creator = oldOrder.Creator;
            
            var order = new Order(oldOrder.Id, client, model.Location, creator, accu, model.Info,
                model.Done); 
            new Order().Update(order);
            return RedirectToAction("Index","Home");
        }

        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
        }
    }
}
