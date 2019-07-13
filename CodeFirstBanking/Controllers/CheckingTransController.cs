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
    public class CheckingTransController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckingTransController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CheckingTrans
        public async Task<IActionResult> Index()
        {
            return View(await _context.CheckingTrans.ToListAsync());
        }

        // GET: CheckingTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkingTrans = await _context.CheckingTrans
                .FirstOrDefaultAsync(m => m.CheckingTransId == id);
            if (checkingTrans == null)
            {
                return NotFound();
            }

            return View(checkingTrans);
        }

        // GET: CheckingTrans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckingTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckingTransId,CheckingId,Time,Amount,Type")] CheckingTrans checkingTrans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkingTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkingTrans);
        }

        // GET: CheckingTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkingTrans = await _context.CheckingTrans.FindAsync(id);
            if (checkingTrans == null)
            {
                return NotFound();
            }
            return View(checkingTrans);
        }

        // POST: CheckingTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckingTransId,CheckingId,Time,Amount,Type")] CheckingTrans checkingTrans)
        {
            if (id != checkingTrans.CheckingTransId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkingTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckingTransExists(checkingTrans.CheckingTransId))
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
            return View(checkingTrans);
        }

        // GET: CheckingTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkingTrans = await _context.CheckingTrans
                .FirstOrDefaultAsync(m => m.CheckingTransId == id);
            if (checkingTrans == null)
            {
                return NotFound();
            }

            return View(checkingTrans);
        }

        // POST: CheckingTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkingTrans = await _context.CheckingTrans.FindAsync(id);
            _context.CheckingTrans.Remove(checkingTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckingTransExists(int id)
        {
            return _context.CheckingTrans.Any(e => e.CheckingTransId == id);
        }
    }
}
