using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Services;
using OnlineBanking.Models;

namespace OnlineBanking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeedbackController : Controller
    {
        private readonly IAccountService service;
        public FeedbackController(IAccountService service)
        {
            this.service = service;
        }
        // Index - Show feedback in index
        public IActionResult Index(string AccountId)
        {
            var feedbacks = service.GetFeedbacks(AccountId);
            return View(feedbacks);
        }

        
    }
}
