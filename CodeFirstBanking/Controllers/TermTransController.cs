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
    public class TermTransController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TermTransController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TermTrans
        public async Task<IActionResult> Index()
        {
            return View(await _context.TermTrans.ToListAsync());
        }

        // GET: TermTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termTrans = await _context.TermTrans
                .FirstOrDefaultAsync(m => m.TermTransId == id);
            if (termTrans == null)
            {
                return NotFound();
            }

            return View(termTrans);
        }

        // GET: TermTrans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TermTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TermTransId,TermId,Time,Amount")] TermTrans termTrans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(termTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(termTrans);
        }

        // GET: TermTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termTrans = await _context.TermTrans.FindAsync(id);
            if (termTrans == null)
            {
                return NotFound();
            }
            return View(termTrans);
        }

        // POST: TermTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TermTransId,TermId,Time,Amount")] TermTrans termTrans)
        {
            if (id != termTrans.TermTransId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(termTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermTransExists(termTrans.TermTransId))
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
            return View(termTrans);
        }

        // GET: TermTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termTrans = await _context.TermTrans
                .FirstOrDefaultAsync(m => m.TermTransId == id);
            if (termTrans == null)
            {
                return NotFound();
            }

            return View(termTrans);
        }

        // POST: TermTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var termTrans = await _context.TermTrans.FindAsync(id);
            _context.TermTrans.Remove(termTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TermTransExists(int id)
        {
            return _context.TermTrans.Any(e => e.TermTransId == id);
        }
    }
}
