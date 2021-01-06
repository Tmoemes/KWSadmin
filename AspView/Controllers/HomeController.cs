using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspView.Models;
using Interface;
using KWSAdmin.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace AspView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static SqlConnection connection;
        private IConfiguration configuration;


        public HomeController(ILogger<HomeController> logger, IConfiguration _configuration)
        {
            configuration = _configuration;
            connection = new SqlConnection(configuration.GetConnectionString("ConnectionString"));
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index(string sortOrder, string searchString)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account");

            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.ClientSortParm = sortOrder == "client" ? "client_desc" : "client";
            ViewBag.AccuSortParm = sortOrder == "accu" ? "accu_desc" : "accu";
            ViewBag.CreatorSortParm = sortOrder == "creator" ? "creator_desc" : "creator";

            var orders = Order.GetAllOrders(connection);

            if (!string.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s =>
                    s.client.LName.Contains(searchString) || s.client.FName.Contains(searchString)).ToList();
            }


            switch (sortOrder)
            {
                case "id_desc":
                    orders = orders.OrderByDescending(s => s.id).ToList();
                    break;
                case "client":
                    orders = orders.OrderBy(s => s.client.LName).ToList();
                    break;
                case "client_desc":
                    orders = orders.OrderByDescending(s => s.client.LName).ToList();
                    break;
                case "accu":
                    orders = orders.OrderBy(s => s.accu.Name).ToList();
                    break;
                case "accu_desc":
                    orders = orders.OrderByDescending(s => s.accu.Name).ToList();
                    break;
                case "creator":
                    orders = orders.OrderBy(s => s.creator.username).ToList();
                    break;
                case "creator_desc":
                    orders = orders.OrderByDescending(s => s.creator.username).ToList();
                    break;
                default:
                    orders = orders.OrderBy(s => s.id).ToList();
                    break;
            }

            return View(orders);
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
            
            Accu.AddAccu(new Accu(0,model.Name,GetCurrentUserId(),model.Specs,connection),connection);

            return RedirectToAction("Index");
        }

        public IActionResult CreateOrder() //todo form to add order details and javascript search for client, accu and user object
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login","Account");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(AspView.Models.OrderViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");
            Order.AddOrder(new Order(0,
                Convert.ToInt32(model.Client.Split(":")[0]),
                model.Location,GetCurrentUserId(),
                Convert.ToInt32(model.Accu.Split(":")[0]),
                model.Info,
                connection), connection);
            return RedirectToAction("Index");
        }

        public IActionResult AddClient() 
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddClient( AspView.Models.CientViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            Client.AddClient(new Client(0, model.FName, model.LName, model.Phone, model.EMail, model.Adres),connection);
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
        }

    }
}
