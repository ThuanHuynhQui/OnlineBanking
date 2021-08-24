using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Services;
using OnlineBanking.ActionFilter;

namespace OnlineBanking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionCheckAdmin]
    public class TransactionController : Controller
    {
        private readonly ITransactionService transService;
        private readonly IAccountService accService;
        private readonly ICardService cardService;
        public TransactionController(ITransactionService transService, IAccountService accService, ICardService cardService)
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
