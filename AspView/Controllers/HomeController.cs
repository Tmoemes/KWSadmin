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
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account");
            return View(Order.GetAllOrders(connection));
        }

        /*public IActionResult Index() //todo show list of all orders with filter/search function
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login","Account");
            

            return View();
        }*/


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

            return View();
        }

        public IActionResult CreateOrder() //todo form to add order details and javascript search for client, acccu and user object
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login","Account");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(AspView.Models.OrderViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Login", "Account");
            Order.AddOrder(new Order(0, model.Client.id,model.Location,GetCurrentUserId(),model.Accu.id,model.Info,connection), connection);
            return View();
        }

        public IActionResult AddClient() //todo add client form and function
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
