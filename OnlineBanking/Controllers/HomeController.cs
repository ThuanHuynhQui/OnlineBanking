using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Services;

namespace OnlineBanking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountService service;
        public HomeController (IAccountService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string AccountId, string password)
        {
            if (service.CheckLogin(AccountId, password).Result)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid credentials, please try again.";
            }
            return View();
        }
    }
}
