using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Models;
using OnlineBanking.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace OnlineBanking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SessionController : Controller
    {
        private readonly IAccountService service;
        public SessionController(IAccountService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string AccountId, string password)
        {
            try
            {
                if (service.CheckLogin(AccountId, password).Result)
                {
                    var account = service.GetAccount(AccountId).Result;
                    HttpContext.Session.SetString("Account", JsonConvert.SerializeObject(account));
                    return RedirectToAction("Index", "Feedback");
                }
                else
                {
                    ViewBag.Error = "Invalid credentials, please try again!";
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View();
        }
    }
}
