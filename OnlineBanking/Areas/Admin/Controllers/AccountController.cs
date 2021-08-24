using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Services;
using OnlineBanking.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;
using OnlineBanking.ActionFilter;
using OnlineBanking.EncryptTool;

namespace OnlineBanking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionCheckAdmin]
    public class AccountController : Controller
    {
        private readonly IAccountService service;
        private readonly EncryptString encrypt = new EncryptString();
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
                if(file != null)
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
                NewUserAccount.Active = true;
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
        [HttpGet]
        public IActionResult Edit(string AccountId)
        {
            UserAccount model = service.GetUserAccount(AccountId).Result;
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(UserAccount userAccount)
        {
            try
            {
                string encryptedPassword = encrypt.Encrypt(userAccount.Password);
                userAccount.Password = encryptedPassword;
                if (service.EditUserAccount(userAccount).Result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Fail to edit user account!";
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View(userAccount);
        }
    }
}
