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
        public static SqlConnection Connection;

        public OrderController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("ConnectionString"));
            _logger = logger;
        }


        public IActionResult CreateOrder()
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");
            OrderViewModel model = new OrderViewModel {Accus = new Accu().GetAllAccus(Connection),Clients = new Client().GetAllClients(Connection)};

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(AspView.Models.OrderViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");

            new Order(model.AccuId, model.Location, GetCurrentUserId(), model.AccuId, model.Info, Connection).AddOrder(Connection);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult OrderView(int id)
        {
            var selectedOrder = new Order().GetById(id, Connection);
            return View(selectedOrder);
        }

        public ActionResult DeleteOrder(int id)
        {
            new Order().Delete(id, Connection);
            return RedirectToAction("Index", "Home");
        }


        public IActionResult UpdateOrder(Order order)
        {
            return View(order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateOrder(OrderViewModel model, Order oldOrder)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");

            var order = new Order(oldOrder.Id, model.ClientId, model.Location, oldOrder.Creator.Id, model.AccuId, model.Info, false, Connection);
            new Order().Update(order, Connection);
            return RedirectToAction("OrderView", oldOrder.Id);
        }

        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
        }
    }
}
