using AspView.Models;
using KWSAdmin.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using KWSAdmin.Persistence.Interface.Dtos;

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
            if (!User.IsInRole("Admin")) return RedirectToAction("Index", "Home");

            var clients = new Client().GetAllClients();
            var accus = new Accu().GetAllAccus();

            if (clients == null || accus == null)
            {
                ModelState.AddModelError("", "Something went wrong while trying to connect to the database ");
                return RedirectToAction("Index", "Home");
            }

            var model = new OrderViewModel { Accus = accus, Clients = clients };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(OrderViewModel model)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Index", "Home");

            if (new Order(model.ClientId, model.Location, GetCurrentUserId(), model.AccuId, model.Info).AddOrder())
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Something went wrong while trying to connect to the database ");
            return View(model);
        }


        [HttpGet]
        public IActionResult OrderView(int id)
        {
            var selectedOrder = new Order().GetOrderById(id);
            if (selectedOrder != null) return View(selectedOrder);
            ModelState.AddModelError("", "Something went wrong while trying to connect to the database ");
            return RedirectToAction("Index", "Home");

        }

        public ActionResult DeleteOrder(int id)
        {
            if (new Order().DeleteOrder(id)) return RedirectToAction("Index", "Home");
            ModelState.AddModelError("", "Something went wrong while trying to connect to the database ");
            return RedirectToAction("OrderView", new {id });
        }


        public IActionResult UpdateOrder(int id)
        {
            if (!User.IsInRole("Admin")) return RedirectToAction("Index", "Home");
            var oldOrder = new Order().GetOrderById(id);

            if (oldOrder == null)
            {
                ModelState.AddModelError("", "Something went wrong while trying to connect to the database ");
                return RedirectToAction("OrderView", new {id });
            }

            var model = new OrderViewModel
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
            if (!User.IsInRole("Admin")) return RedirectToAction("Index", "Home");

            var oldOrder = new Order().GetOrderById(model.Id);

            var client = new Client().GetClientById(model.ClientId);
            var accu = new Accu().GetAccuById(model.AccuId);
            var creator = oldOrder.Creator;

            var order = new Order(oldOrder.Id, client, model.Location, creator, accu, model.Info,
                model.Done);

            if (new Order().UpdateOrder(order))
            {
                return RedirectToAction("OrderView", new { id = model.Id });
            }

            ModelState.AddModelError("", "Something went wrong while trying to connect to the database ");
            return View(model);
        }


        public ActionResult UpdateOrderLocation(int id, Location location)//todo krijgt niet de juiste locatie mee
        {
            if(!new Order().UpdateOrderLocation(id, location)) ModelState.AddModelError("", "Something went wrong while trying to connect to the database ");

            return RedirectToAction("OrderView", new {id});
        }



        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
        }
    }
}
