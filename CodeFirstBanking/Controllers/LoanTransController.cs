using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirstBanking.Data;
using CodeFirstBanking.Models;

namespace CodeFirstBanking.Controllers
{
    public class LoanTransController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoanTransController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LoanTrans
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoanTrans.ToListAsync());
        }

        // GET: LoanTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanTrans = await _context.LoanTrans
                .FirstOrDefaultAsync(m => m.LoanTransId == id);
            if (loanTrans == null)
            {
                return NotFound();
            }

            return View(loanTrans);
        }

        // GET: LoanTrans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoanTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanTransId,LoanId,Time,Amount,Type")] LoanTrans loanTrans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loanTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loanTrans);
        }

        // GET: LoanTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanTrans = await _context.LoanTrans.FindAsync(id);
            if (loanTrans == null)
            {
                return NotFound();
            }
            return View(loanTrans);
        }

        // POST: LoanTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanTransId,LoanId,Time,Amount,Type")] LoanTrans loanTrans)
        {
            if (id != loanTrans.LoanTransId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanTransExists(loanTrans.LoanTransId))
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
            return View(loanTrans);
        }

        // GET: LoanTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanTrans = await _context.LoanTrans
                .FirstOrDefaultAsync(m => m.LoanTransId == id);
            if (loanTrans == null)
            {
                return NotFound();
            }

            return View(loanTrans);
        }

        // POST: LoanTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loanTrans = await _context.LoanTrans.FindAsync(id);
            _context.LoanTrans.Remove(loanTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanTransExists(int id)
        {
            return _context.LoanTrans.Any(e => e.LoanTransId == id);
        }
    }
}
