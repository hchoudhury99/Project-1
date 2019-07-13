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
    public class CheckingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Transfer()
        {

            Checking checking = _context.Checking.Find(1);
            Business business = _context.Business.Find(1);

            TempData["BBalance"] = business.AccountBalance;
            TempData["BTemp"] = 0;
            business.AccountBalance = (int)TempData["BTemp"];

            TempData["CBalance"] = checking.AccountBalance;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Transfer(Checking checking, Business business)
        {
            if (ModelState.IsValid)
            {
                int withdrawamount = checking.AccountBalance;
                checking.AccountBalance = (int)TempData["CBalance"];
                

                if (checking.AccountBalance - withdrawamount < 0)
                {
                    return View();
                }

                else
                {
                    checking.AccountBalance -= withdrawamount;

                    int depositamount = business.AccountBalance;
                    business.AccountBalance += (int)TempData["BBalance"];
                    _context.Entry(business).State = EntityState.Modified;
                    _context.BusinessTrans.Add(new BusinessTrans
                    {
                        Time = DateTime.Now,
                        Amount = depositamount,
                        BusinessId = business.BusinessId,
                        Type = "TransferAdd"

                    });
                    _context.SaveChanges();

                    _context.Entry(checking).State = EntityState.Modified;
                    _context.CheckingTrans.Add(new CheckingTrans
                    {
                        Time = DateTime.Now,
                        Amount = withdrawamount,
                        CheckingId = checking.CheckingId,
                        Type = "TransferSub"

                    });
                    _context.SaveChanges();
                }
            }

            return View();

        }

        public ActionResult Deposit()
        {
            
            Checking checking = _context.Checking.Find(1);

            TempData["Balance"] = checking.AccountBalance;
            TempData["Temp"] = 0;
            checking.AccountBalance = (int)TempData["Temp"];

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Deposit (Checking checking)
        {
            if (ModelState.IsValid)
            {
                int depositamount = checking.AccountBalance;
                checking.AccountBalance += (int) TempData["Balance"];
                _context.Entry(checking).State = EntityState.Modified;
                _context.CheckingTrans.Add(new CheckingTrans
                {
                    Time = DateTime.Now,
                    Amount = depositamount,
                    CheckingId = checking.CheckingId,
                    Type = "Deposit"

                });
                _context.SaveChanges();
            }

            return View();
            
        }

        public ActionResult Withdraw()
        {
            Checking checking = _context.Checking.Find(1);

            TempData["Balance"] = checking.AccountBalance;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Withdraw(Checking checking)
        {
            if (ModelState.IsValid)
            {
                int withdrawamount = checking.AccountBalance;
                checking.AccountBalance = (int)TempData["Balance"];

                if (checking.AccountBalance - withdrawamount < 0)
                {
                    return View();
                }
                else
                {
                    checking.AccountBalance -= withdrawamount;
                    _context.Entry(checking).State = EntityState.Modified;
                    _context.CheckingTrans.Add(new CheckingTrans
                    {
                        Time = DateTime.Now,
                        Amount = withdrawamount,
                        CheckingId = checking.CheckingId,
                        Type = "Withdrawal"

                    });
                    _context.SaveChanges();
                }
            }

            return View();

        }

        // GET: Checkings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Checking.ToListAsync());
        }

        // GET: Checkings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checking = await _context.Checking
                .FirstOrDefaultAsync(m => m.CheckingId == id);
            if (checking == null)
            {
                return NotFound();
            }

            return View(checking);
        }

        // GET: Checkings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Checkings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckingId,Interest,AccountBalance")] Checking checking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checking);
        }

        // GET: Checkings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checking = await _context.Checking.FindAsync(id);
            if (checking == null)
            {
                return NotFound();
            }
            return View(checking);
        }

        // POST: Checkings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckingId,Interest,AccountBalance")] Checking checking)
        {
            if (id != checking.CheckingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckingExists(checking.CheckingId))
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
            return View(checking);
        }

        // GET: Checkings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checking = await _context.Checking
                .FirstOrDefaultAsync(m => m.CheckingId == id);
            if (checking == null)
            {
                return NotFound();
            }

            return View(checking);
        }

        // POST: Checkings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checking = await _context.Checking.FindAsync(id);
            _context.Checking.Remove(checking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckingExists(int id)
        {
            return _context.Checking.Any(e => e.CheckingId == id);
        }
    }
}
