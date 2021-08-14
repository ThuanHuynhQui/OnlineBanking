using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Models;
using OnlineBanking.Repository;

namespace OnlineBanking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CardTypesController : Controller
    {
        private readonly Services.ICardService service;

        public CardTypesController(Services.ICardService service)
        {
            this.service = service;
        }

        // GET: Admin/CardTypes
        public IActionResult Index()
        {
            return View(service.GetCardTypes().Result);
        }

        // GET: Admin/CardTypes/Details/5
        public IActionResult Details(int id)
        {
            var cardType = service.GetCardType(id).Result;
            return View(cardType);
        }

        // GET: Admin/CardTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CardTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CardType cardType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.AddCardType(cardType);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.erorr = "Failed action";
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Admin/CardTypes/Edit/5
        public IActionResult Edit(int id)
        {
            var cardType = service.GetCardType(id).Result;
            return View(cardType);
        }

        // POST: Admin/CardTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CardType cardType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.EditCardType(cardType);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.erorr = "Failed action";
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Admin/CardTypes/Delete/5
        public IActionResult Delete(int id)
        {
            service.DeleteCardType(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
