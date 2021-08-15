using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Services;
using OnlineBanking.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace OnlineBanking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService service;
        public AccountController(IAccountService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var accounts = service.GetAccounts().Result;
            return View(accounts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserAccount NewUserAccount, IFormFile file)
        {
            try
            {
                if(file.FileName.Length > 0)
                {
                    var path = Path.Combine("wwwroot/Images", file.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);
                    NewUserAccount.Avatar = file.FileName;
                }
                else
                {
                    NewUserAccount.Avatar = "NoAvatar.png";
                }
                NewUserAccount.OpenDate = DateTime.Now.ToShortDateString();
                if (service.AddAccount(NewUserAccount).Result)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ViewBag.Error = "Account Id is already exist";
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View();
        }

        public IActionResult Details(string AccountId)
        {
            UserAccount userAccount = service.GetUserAccount(AccountId).Result;
            return View(userAccount);
        }

        public IActionResult ChangeRole(string AccountId)
        {
            try
            {
                var EditAccount = service.GetAccount(AccountId).Result;
                EditAccount.Role = !EditAccount.Role;
                if (service.EditAccount(EditAccount).Result)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ViewBag.Error = "Fail to edit account";
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View();
        }
        public IActionResult ChangeActive(string AccountId)
        {
            try
            {
                var EditAccount = service.GetAccount(AccountId).Result;
                EditAccount.Active = !EditAccount.Active;
                if (service.EditAccount(EditAccount).Result)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ViewBag.Error = "Fail to edit account";
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
