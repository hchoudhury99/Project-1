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
    public class BusinessTransController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessTransController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BusinessTrans
        public async Task<IActionResult> Index()
        {


            return View(await _context.BusinessTrans.ToListAsync());
        }

        // GET: BusinessTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessTrans = await _context.BusinessTrans
                .FirstOrDefaultAsync(m => m.BusinessTransId == id);
            if (businessTrans == null)
            {
                return NotFound();
            }

            return View(businessTrans);
        }

        // GET: BusinessTrans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessTrans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessTransId,BusinessId,Time,Amount,Type")] BusinessTrans businessTrans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessTrans);
        }

        // GET: BusinessTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessTrans = await _context.BusinessTrans.FindAsync(id);
            if (businessTrans == null)
            {
                return NotFound();
            }
            return View(businessTrans);
        }

        // POST: BusinessTrans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessTransId,BusinessId,Time,Amount,Type")] BusinessTrans businessTrans)
        {
            if (id != businessTrans.BusinessTransId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessTransExists(businessTrans.BusinessTransId))
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
            return View(businessTrans);
        }

        // GET: BusinessTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessTrans = await _context.BusinessTrans
                .FirstOrDefaultAsync(m => m.BusinessTransId == id);
            if (businessTrans == null)
            {
                return NotFound();
            }

            return View(businessTrans);
        }

        // POST: BusinessTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var businessTrans = await _context.BusinessTrans.FindAsync(id);
            _context.BusinessTrans.Remove(businessTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessTransExists(int id)
        {
            return _context.BusinessTrans.Any(e => e.BusinessTransId == id);
        }
    }
}
