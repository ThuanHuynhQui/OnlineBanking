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
            var feedbacks = service.GetFeedbacks(AccountId).Result;
            return View(feedbacks);
        }

        [HttpGet]
        public IActionResult Reply(int FeedbackId)
        {
            var feedback = service.GetFeedback(FeedbackId).Result;
            return View(feedback);
        }
        [HttpPost]
        public IActionResult Reply(Feedback RepliedFeedback)
        {
            try
            {
                if (service.EditFeedback(RepliedFeedback).Result)
                {
                    return RedirectToAction("Index", "Feedback");
                }
                else
                {
                    ViewBag.Error = "Fail to reply feedback";
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
