using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Controllers
{
    [Area("Admin")]
    public class CardsController : Controller
    {
        private Services.ICardService service;
        private Services.IAccountService _service;
        public CardsController(Services.ICardService service, Services.IAccountService _service)
        {
            this.service = service;
            this._service = _service;
        }
        // GET: CardsController
        public ActionResult Index(string AccountId)
        {
            return View(service.GetCards(AccountId).Result);
        }

        // GET: CardsController/Details/5
        public ActionResult Details(string id)
        {
            var findOne = service.GetCard(id).Result;
            return View(findOne);
        }

        // GET: CardsController/Create
        public ActionResult Create()
        {
            var accountList = _service.GetAccounts().Result;
            ViewBag.acList = new SelectList(accountList, "AccountId", "AccountId");
            var typeList = service.GetCardTypes().Result;
            ViewBag.typeNo = new SelectList(typeList, "TypeId", "TypeName");
            return View();
        }

        // POST: CardsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Card card)
        {
            try 
            { 
                service.AddCard(card);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.erorr = e.Message;
            }
            return View();
        }

        // GET: CardsController/Edit/5
        public ActionResult Edit(string id)
        {
            var card = service.GetCard(id).Result;
            return View(card);
        }

        // POST: CardsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Card card)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.EditCard(card);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.erorr = "Failed action";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CardsController/Delete/5
        public IActionResult Delete(string id)
        {
            try
            {
                service.DeleteCard(id);
                return RedirectToAction(nameof(Index)); 
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
