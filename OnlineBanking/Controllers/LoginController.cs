using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OnlineBanking.Models;
using System.Text;
using OnlineBanking.EncryptTool;
using MimeKit;
using MailKit.Net.Smtp;

namespace OnlineBanking.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountService service;
        private readonly EncryptString encrypt = new EncryptString();
        public LoginController(IAccountService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("Account") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string AccountId, string password)
        {
            try
            {
                string encryptedPassword = encrypt.Encrypt(password);
                string result = service.CheckLoginCustomer(AccountId, encryptedPassword).Result;
                if (result.Equals("true"))
                {
                    var account = service.GetAccount(AccountId).Result;
                    HttpContext.Session.SetString("Account", JsonConvert.SerializeObject(account));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = result;
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserAccount userAccount)
        {
            userAccount.Password = "";
            try
            {
                if (!service.CheckEmail(userAccount.Email).Result)
                {
                    if (!service.CheckAccountId(userAccount.AccountId).Result)
                    {
                        if (!service.CheckIdentityId(userAccount.IdentityId).Result)
                        {
                            userAccount.Password = encrypt.Encrypt(userAccount.Password);
                            userAccount.Avatar = "NoAvatar.png";
                            userAccount.Active = true;
                            if (service.AddAccount(userAccount).Result)
                            {
                                var account = service.GetAccount(userAccount.AccountId).Result;
                                HttpContext.Session.SetString("Account", JsonConvert.SerializeObject(account));
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewBag.Error = "Fail to create account.";
                            }
                        }
                        else
                        {
                            ViewBag.Error = "This Identity ID is already existed. Login or contact with the staff at the Bank if you're having problems with the account";
                        }
                    }
                    else
                    {
                        ViewBag.Error = "This Account ID is already existed. Please try another...";
                    }
                }
                else
                {
                    ViewBag.Error = "This email is already existed. Please try another...";
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View(userAccount);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Account");
            return RedirectToAction("Login", "Login");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            if (service.CheckEmail(email).Result)
            {
                return RedirectToAction("VerifyCode", new { email = email });
            }
            else
            {
                ViewBag.Error = "Your email is not exist in the system. Please try again...";
            }
            return View();
        }

        [HttpGet]
        public IActionResult VerifyCode(string email)
        {
            string token = CodeGenerate();
            SendEmail(email, token);
            string encryptedToken = encrypt.Encrypt(token);
            ViewBag.token = encryptedToken;
            ViewBag.email = email;
            return View();
        }
        [HttpPost]
        public IActionResult VerifyCode(string code, string token, string email)
        {
            string encryptedCode = encrypt.Encrypt(code);
            ViewBag.token = token;
            ViewBag.email = email;
            if (encryptedCode == token)
            {
                return RedirectToAction("ResetPassword", new { email = email});
            }
            else
            {
                ViewBag.Error = "Your code is not match the code in your email, please check your email again!";
            }
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string email)
        {
            ViewBag.email = email;
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(string newPassword, string email)
        {
            try
            {
                ViewBag.email = email;
                Account editAccount = service.GetAccountByEmail(email).Result;
                editAccount.Password = encrypt.Encrypt(newPassword);
                if (service.EditAccount(editAccount).Result)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Error = "Fail to reset your password due to server error. Please try again later...";
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View();
        }

        //Code generate for forgot password
        private string CodeGenerate()
        {
            const string Letters = "abcdefghijklmnopqrstuvwxyz";
            char[] Alphanumeric = (Letters + Letters.ToUpper() + "0123456789").ToCharArray();
            StringBuilder result = new StringBuilder();
            Random rn = new Random();
            for (int i = 0; i < 10; i++)
            {
                result.Append(Alphanumeric[rn.Next(Alphanumeric.Length)]);
            }
            return result.ToString();
        }

        //Send code to email
        private void SendEmail(string email, string code)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("OnlineBanking System", "Smtp1235023@gmail.com"));
            message.To.Add(new MailboxAddress("Receiver", email));
            message.Subject = "Recover password OnlineBanking";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("You have request a recover password request. Your code is: ");
            stringBuilder.AppendLine(code);
            stringBuilder.AppendLine("Please enter this code in the reset password page.");
            stringBuilder.AppendLine("-----------------------------------");
            stringBuilder.AppendLine("This is automatic message, please do not reply.");
            message.Body = new TextPart("plain")
            {
                Text = stringBuilder.ToString()
            };
            using(var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("smtp1235023@gmail.com", "iygbncffkpygybhm");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
