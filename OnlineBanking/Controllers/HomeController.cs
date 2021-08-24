using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Services;
using OnlineBanking.ActionFilter;

namespace OnlineBanking.Controllers
{
    [SessionCheckCustomer]
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
        
    }
}
