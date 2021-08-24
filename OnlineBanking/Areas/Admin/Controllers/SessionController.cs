using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Models;
using OnlineBanking.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using OnlineBanking.EncryptTool;

namespace OnlineBanking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SessionController : Controller
    {
        private readonly IAccountService service;
        private readonly EncryptString encrypt = new EncryptString();
        public SessionController(IAccountService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Account") != null)
            {
                Account a = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("Account"));
                if (a.Active && a.Role)
                {
                    return RedirectToAction("Index", "Feedback");
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string AccountId, string password)
        {
            try
            {
                string encryptedPassword = encrypt.Encrypt(password);
                if (service.CheckLoginAdmin(AccountId, encryptedPassword).Result)
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
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Account");
            return RedirectToAction("Login", "Session");
        }
    }
}
