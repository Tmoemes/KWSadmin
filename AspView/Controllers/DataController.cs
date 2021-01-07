using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspView.Models;
using KWSAdmin.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspView.Controllers
{
    public class DataController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static SqlConnection Connection;


        public DataController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("ConnectionString"));
            _logger = logger;
        }


        #region Accu
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

            Accu.AddAccu(new Accu(0, model.Name, GetCurrentUserId(), model.Specs, Connection), Connection);

            return RedirectToAction("Index","Home");
        }
        #endregion

        #region Client
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

            Client.AddClient(new Client(0, model.FName, model.LName, model.Phone, model.EMail, model.Adres), Connection);
            return RedirectToAction("Index","Home");
        }
        #endregion


        #region Order
        public IActionResult CreateOrder()
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(AspView.Models.OrderViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");
            Order.AddOrder(new Order(0,
                Convert.ToInt32(model.Client.Split(":")[0]),
                model.Location, GetCurrentUserId(),
                Convert.ToInt32(model.Accu.Split(":")[0]),
                model.Info,false,
                Connection), Connection);
            return RedirectToAction("Index","Home");
        }


        [HttpGet]
        public IActionResult OrderView(int id)
        {
            var selectedOrder = Order.GetById(id, Connection);
            return View(selectedOrder);
        }

        #endregion


        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
        }
    }
}
