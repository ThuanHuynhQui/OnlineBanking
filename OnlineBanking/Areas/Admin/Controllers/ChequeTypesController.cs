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
    public class ChequeTypesController : Controller
    {
        private readonly BankingContext _context;

        public ChequeTypesController(BankingContext context)
        {
            _context = context;
        }

        // GET: ChequeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChequeTypes.ToListAsync());
        }

        // GET: ChequeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chequeTypes = await _context.ChequeTypes
                .FirstOrDefaultAsync(m => m.ChequeTypeId == id);
            if (chequeTypes == null)
            {
                return NotFound();
            }

            return View(chequeTypes);
        }

        // GET: ChequeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChequeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChequeTypeId,ChequeName")] ChequeType chequeTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chequeTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chequeTypes);
        }

        // GET: ChequeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chequeTypes = await _context.ChequeTypes.FindAsync(id);
            if (chequeTypes == null)
            {
                return NotFound();
            }
            return View(chequeTypes);
        }

        // POST: ChequeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChequeTypeId,ChequeName")] ChequeType chequeTypes)
        {
            if (id != chequeTypes.ChequeTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chequeTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChequeTypesExists(chequeTypes.ChequeTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(chequeTypes);
        }

        // GET: ChequeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chequeTypes = await _context.ChequeTypes
                .FirstOrDefaultAsync(m => m.ChequeTypeId == id);
            if (chequeTypes == null)
            {
                return NotFound();
            }

            return View(chequeTypes);
        }

        // POST: ChequeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chequeTypes = await _context.ChequeTypes.FindAsync(id);
            _context.ChequeTypes.Remove(chequeTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChequeTypesExists(int id)
        {
            return _context.ChequeTypes.Any(e => e.ChequeTypeId == id);
        }
    }
}
