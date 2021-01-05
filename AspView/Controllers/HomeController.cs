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
using KWSAdmin.DALFactory;
using KWSAdmin.Persistence;
using KWSAdmin.Persistence.Interface.Dtos;
using KWSAdmin.Persistence.Interface.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace AspView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static SqlConnection connection;
        private IConfiguration configuration;
        private IOrderDal orderDal = OrderFactory.GetOrderDal();
        private IClientDal clientDal = ClientFactory.GetClientDal();
        private IAccuDal accuDal = AccuFactory.GetAccuDal();
        private IUserDal userDal = AccountFactory.GetUserDal();


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
            
            accuDal.Add(new AccuDto(0,model.Name,
                userDal.GetById(Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value), connection),
                model.Specs),connection);
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
            Order.AddOrder()
            
            orderDal.Add(new OrderDto(0,clientDal.GetById(Convert.ToInt32(model.Client),connection),
                model.Location,
                userDal.GetById(Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value),connection),
                accuDal.GetById(Convert.ToInt32(model.Accu),connection),
                model.Info
                ),connection);
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

            Client.AddClient(new Client(new ClientDto(0, model.FName, model.LName, model.Phone, model.EMail,
                model.Adres)),connection);
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
