using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirstBanking.Data;
using CodeFirstBanking.Models;
using Microsoft.AspNetCore.Authorization;

namespace CodeFirstBanking.Controllers
{
    [Authorize]
    public class TermsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TermsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Deposit()
        {

            Term term = _context.Term.Find(1);
            Console.WriteLine(term.AccountBalance);

            TempData["Balance"] = term.AccountBalance;
            TempData["Temp"] = 0;
            term.AccountBalance = (int)TempData["Temp"];

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Deposit(Term term)
        {
            if (ModelState.IsValid)
            {
                int depositamount = term.AccountBalance;
                term.AccountBalance += (int)TempData["Balance"];
                _context.Entry(term).State = EntityState.Modified;

                _context.TermTrans.Add(new TermTrans
                {
                    Time = DateTime.Now,
                    Amount = depositamount,
                    TermId = term.TermId,
                    Type = "Deposit"

                }); 
                

                _context.SaveChanges();
            }

            return View();

        }

        public ActionResult Withdraw()
        {
            Term term = _context.Term.Find(1);

            TempData["Balance"] = term.AccountBalance;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Withdraw(Term term)
        {
            if (ModelState.IsValid)
            {
                int withdrawamount = term.AccountBalance;
                term.AccountBalance = (int)TempData["Balance"];

                if (term.AccountBalance - withdrawamount < 0)
                {
                    return View();
                }
                else
                {
                    term.AccountBalance -= withdrawamount;
                    _context.Entry(term).State = EntityState.Modified;

                    _context.TermTrans.Add(new TermTrans
                    {
                        Time = DateTime.Now,
                        Amount = withdrawamount,
                        TermId = term.TermId,
                        Type = "Withdrawal"
                    }); ;

                    _context.SaveChanges();
                }
            }

            return View();

        }

        // GET: Terms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Term.ToListAsync());
        }

        // GET: Terms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var term = await _context.Term
                .FirstOrDefaultAsync(m => m.TermId == id);
            if (term == null)
            {
                return NotFound();
            }

            return View(term);
        }

        // GET: Terms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Terms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TermId,AccountBalance")] Term term)
        {
            if (ModelState.IsValid)
            {
                _context.Add(term);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(term);
        }

        // GET: Terms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var term = await _context.Term.FindAsync(id);
            if (term == null)
            {
                return NotFound();
            }
            return View(term);
        }

        // POST: Terms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TermId,AccountBalance")] Term term)
        {
            if (id != term.TermId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(term);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermExists(term.TermId))
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
            return View(term);
        }

        // GET: Terms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var term = await _context.Term
                .FirstOrDefaultAsync(m => m.TermId == id);
            if (term == null)
            {
                return NotFound();
            }

            return View(term);
        }

        // POST: Terms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var term = await _context.Term.FindAsync(id);
            _context.Term.Remove(term);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TermExists(int id)
        {
            return _context.Term.Any(e => e.TermId == id);
        }
    }
}
