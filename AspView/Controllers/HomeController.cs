﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspView.Models;
using KWSAdmin.Application;
using Microsoft.Extensions.Configuration;

namespace AspView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static SqlConnection Connection;


        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("ConnectionString"));
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index(string sortOrder, string searchString)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account");

            ViewBag.IdSortParm = string.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.ClientSortParm = sortOrder == "client" ? "client_desc" : "client";
            ViewBag.AccuSortParm = sortOrder == "accu" ? "accu_desc" : "accu";
            ViewBag.CreatorSortParm = sortOrder == "creator" ? "creator_desc" : "creator";

            var orders = Order.GetAllOrders(Connection);

            //Filters the list of order according to the searchString
            if (!string.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s =>
                    s.Client.LName.Contains(searchString) || s.Client.FName.Contains(searchString)).ToList();
            }

            //Reads out chosen sort order and sorts orders accordingly
            orders = sortOrder switch
            {
                "id_desc" => orders.OrderByDescending(s => s.Id).ToList(),
                "client" => orders.OrderBy(s => s.Client.LName).ToList(),
                "client_desc" => orders.OrderByDescending(s => s.Client.LName).ToList(),
                "accu" => orders.OrderBy(s => s.Accu.Name).ToList(),
                "accu_desc" => orders.OrderByDescending(s => s.Accu.Name).ToList(),
                "creator" => orders.OrderBy(s => s.Creator.Username).ToList(),
                "creator_desc" => orders.OrderByDescending(s => s.Creator.Username).ToList(),
                _ => orders.OrderBy(s => s.Id).ToList()
            };

            return View(orders);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        

    }
}
