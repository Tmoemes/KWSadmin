﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KWSAdmin.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspView.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static SqlConnection Connection;


        public ClientController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("ConnectionString"));
            _logger = logger;
        }


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

            new Client().AddClient(new Client(model.FName, model.LName, model.Phone, model.EMail, model.Adres), Connection);
            return RedirectToAction("Index", "Home");
        }


        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
        }


    }
}