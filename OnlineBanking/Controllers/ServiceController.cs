using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OnlineBanking.Services;
using OnlineBanking.Models;
using OnlineBanking.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineBanking.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ICardService cardService;
        private readonly ITransactionService transactionService;
        private readonly BankingContext context;
        public ServiceController(ICardService cardService, ITransactionService transactionService, BankingContext context)
        {
            this.cardService = cardService;
            this.transactionService = transactionService;
            this.context = context;
        }
        // GET: ServiceController
        public ActionResult Index(string id)
        {
            return View(cardService.GetCards(id).Result);
        }


        // GET: ServiceController/Search/5
        public ActionResult Search(string receiverID)
        {
            var i = context.Cards.ToList();
            var ReceiverID = cardService.GetCards(receiverID).Result;
            if (!string.IsNullOrEmpty(receiverID))
            {
                /*ReceiverID = ReceiverID.Where(o=>o.car)
                ViewBag.ReceiverID = ReceiverID;*/
                return View();
            }
            else
            {
                ViewBag.ReceiverID = cardService.GetCard(receiverID).Result; ;
                return View();
            }
        }

        // GET: ServiceController/Create
        public ActionResult FundTransfer(string sid,string id)
        {
            var getSenderID = cardService.GetCard(id).Result;
            var getReceiverID = cardService.GetCards(sid).Result;
            /*if (!string.IsNullOrEmpty(sid))
            {
                getReceiverID = getReceiverID.Where(f => f.CardId.Contains(sid));
                ViewBag.ReceiverID = getReceiverID;
            }*/
            ViewBag.SenderID = getSenderID;
            ViewBag.ReceiverID = new SelectList(getReceiverID,"AccountId", "CardId");

            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FundTransfer(Transaction transaction)
        {
            var getSenderID = cardService.GetCard(transaction.SenderCardId).Result;
            ViewBag.SenderID = getSenderID;
            try
            {
                if (transactionService.TransferMoney(transaction).Result)
                {
                    transaction.Status = true;
                    transactionService.AddTransaction(transaction);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    transaction.Status = false;
                    transaction.Reason = "Fail";
                    if (transactionService.AddTransaction(transaction).Result)
                    {
                        ViewBag.Error = "Action Fail";
                    }
                    else
                    {
                        ViewBag.Error = "Add transaction fail";
                    }
                    
                }
                /*return ViewBag.erorr = "Action Failed!!";*/
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View();
        }

        // GET: ServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View();
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
