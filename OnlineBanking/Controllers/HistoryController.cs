using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Models;
using OnlineBanking.Repository;

using OnlineBanking.Services;
namespace OnlineBanking.Controllers
{
    public class HistoryController : Controller
    {
        private readonly ITransactionService transService;
        private readonly IAccountService accService;
        private readonly ICardService cardService;
        public HistoryController(ITransactionService transService, IAccountService accService, ICardService cardService)
        {
            this.transService = transService;
            this.accService = accService;
            this.cardService = cardService;
        }
        public IActionResult Index(string cardId)
        {
            var transactions = transService.GetTransactions(cardId).Result;
            return View(transactions);
        }
        public IActionResult Details(int transactionId)
        {
            var transaction = transService.GetTransaction(transactionId).Result;
            ViewBag.Date = transaction.Time.Substring(0, 10);
            var senderUid = cardService.GetCard(transaction.SenderCardId);
            var receiverUid = cardService.GetCard(transaction.ReceiverCardId);
            ViewBag.Sender = accService.GetUserAccount(senderUid.Result.AccountId).Result;
            ViewBag.Receiver = accService.GetUserAccount(receiverUid.Result.AccountId).Result;
            return View(transaction);
        }
    }
}
