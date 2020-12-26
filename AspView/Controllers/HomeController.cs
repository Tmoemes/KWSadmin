﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspView.Models;
using KWSAdmin.Application;
using KWSAdmin.Persistence.Interface.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace AspView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        
        public IActionResult Index() //todo show list of all orders with filter/search function
        {
            return View();
        }
        [Authorize]

        public IActionResult CreateOrder() //todo form to add order details and javascript search for client, acccu and user object
        {
            return View();
        }
        public IActionResult AddClient() //todo add client form and function
        {
            return View();
        }

        /*public Task<ActionResult> AddClient(KWSAdmin.Application.Client model)
        {
            if (!ModelState.IsValid) return View(model);

            Client.AddClient(new Client(new ClientDto(0, model.FName, model.LName, model.Phone, model.EMail,
                model.Adres)));

        }*/



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
