using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Models;
using OnlineBanking.Services;

namespace OnlineBanking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        // Index - Show feedback in index
        public IActionResult Index()
        {
            return View();
        }
    }
}
