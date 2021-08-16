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
    public class ChequesController : Controller
    {
        private readonly BankingContext _context;
        private readonly Services.IChequeService _service;
        private readonly Services.ICardService service;
        public ChequesController(BankingContext context, Services.ICardService service, Services.IChequeService _service)
        {
            _context = context;
            this.service = service;
            this._service = _service;
        }

        // GET: Cheques
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cheques.ToListAsync());
        }

        // GET: Cheques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheques = await _context.Cheques
                .FirstOrDefaultAsync(m => m.ChequeId == id);
            if (cheques == null)
            {
                return NotFound();
            }

            return View(cheques);
        }

        // GET: Cheques/Create
        public IActionResult Create(string cid)
        {
            var getCardID = service.GetCards(cid).Result;
            ViewBag.getCardID = new SelectList(getCardID, "CardId", "CardId");
            var getTypeID = _service.GetChequeTypes().Result;
            ViewBag.getTypeID = new SelectList(getTypeID, "ChequeTypeId", "ChequeName");
            return View();
        }

        // POST: Cheques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cheques cheques)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cheques);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cheques);
        }

        // GET: Cheques/Edit/5
        public async Task<IActionResult> Edit(int? id, string cid)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheques = await _context.Cheques.FindAsync(id);
            var getCardID = service.GetCards(cid).Result;
            ViewBag.getCardID = new SelectList(getCardID, "CardId", "CardId");
            var getTypeID = _service.GetChequeTypes().Result;
            ViewBag.getTypeID = new SelectList(getTypeID, "ChequeTypeId", "ChequeName");
            if (cheques == null)
            {
                return NotFound();
            }
            return View(cheques);
        }

        // POST: Cheques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Cheques cheques)
        {
            if (id != cheques.ChequeId)
            {
                return NotFound();
            }
            else
            {
                _context.Update(cheques);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Cheques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheques = await _context.Cheques
                .FirstOrDefaultAsync(m => m.ChequeId == id);
            if (cheques == null)
            {
                return NotFound();
            }

            return View(cheques);
        }

        // POST: Cheques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cheques = await _context.Cheques.FindAsync(id);
            _context.Cheques.Remove(cheques);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChequesExists(int id)
        {
            return _context.Cheques.Any(e => e.ChequeId == id);
        }
    }
}
