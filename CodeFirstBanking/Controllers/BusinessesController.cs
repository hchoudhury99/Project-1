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
    public class BusinessesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Transfer()
        {
            
            Business business = _context.Business.Find(1);
            Checking checking = _context.Checking.Find(1);

            TempData["CBalance"] = checking.AccountBalance;
            TempData["CTemp"] = 0;
            checking.AccountBalance = (int)TempData["CTemp"];

            TempData["BBalance"] = business.AccountBalance;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Transfer(Business business, Checking checking)
        {
            if (ModelState.IsValid)
            {
                int depositamount = checking.AccountBalance;
                checking.AccountBalance += (int)TempData["CBalance"];
                _context.Entry(checking).State = EntityState.Modified;
                _context.CheckingTrans.Add(new CheckingTrans
                {
                    Time = DateTime.Now,
                    Amount = depositamount,
                    CheckingId = checking.CheckingId,
                    Type = "TransferAdd"

                });
                _context.SaveChanges();

                int withdrawamount = business.AccountBalance;
                business.AccountBalance = (int)TempData["BBalance"];
                business.AccountBalance -= withdrawamount;
                _context.Entry(business).State = EntityState.Modified;
                _context.BusinessTrans.Add(new BusinessTrans
                {
                    Time = DateTime.Now,
                    Amount = withdrawamount,
                    BusinessId = business.BusinessId,
                    Type = "TransferSub"

                });
                _context.SaveChanges();

                if (business.AccountBalance - withdrawamount < 0)
                {
                    return View("Message");   
                }
            }

            return View();

        }

        public ActionResult Deposit()
        {
            Business business = _context.Business.Find(1);

            TempData["Balance"] = business.AccountBalance;
            TempData["Temp"] = 0;
            business.AccountBalance = (int)TempData["Temp"];

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Deposit(Business business)
        {
            if (ModelState.IsValid)
            {
                int depositamount = business.AccountBalance;
                business.AccountBalance += (int)TempData["Balance"];
                _context.Entry(business).State = EntityState.Modified;
                _context.BusinessTrans.Add(new BusinessTrans
                {
                    Time = DateTime.Now,
                    Amount = depositamount,
                    BusinessId = business.BusinessId,
                    Type = "Deposit"

                });
                _context.SaveChanges();
            }

            return View();

        }

        public ActionResult Withdraw()
        {
            Business business = _context.Business.Find(1);

            TempData["Balance"] = business.AccountBalance;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Withdraw(Business business)
        {
            if (ModelState.IsValid)
            {
                int withdrawamount = business.AccountBalance;
                business.AccountBalance = (int)TempData["Balance"];
                business.AccountBalance -= withdrawamount;
                _context.Entry(business).State = EntityState.Modified;
                _context.BusinessTrans.Add(new BusinessTrans
                {
                    Time = DateTime.Now,
                    Amount = withdrawamount,
                    BusinessId = business.BusinessId,
                    Type = "Withdrawal"

                });
                _context.SaveChanges();
            }

            return View();

        }

        // GET: Businesses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Business.ToListAsync());
        }

        // GET: Businesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var business = await _context.Business
                .FirstOrDefaultAsync(m => m.BusinessId == id);
            if (business == null)
            {
                return NotFound();
            }

            return View(business);
        }

        // GET: Businesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Businesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessId,AccountBalance")] Business business)
        {
            if (ModelState.IsValid)
            {
                _context.Add(business);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(business);
        }

        // GET: Businesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var business = await _context.Business.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }
            return View(business);
        }

        // POST: Businesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessId,AccountBalance")] Business business)
        {
            if (id != business.BusinessId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(business);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessExists(business.BusinessId))
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
            return View(business);
        }

        // GET: Businesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var business = await _context.Business
                .FirstOrDefaultAsync(m => m.BusinessId == id);
            if (business == null)
            {
                return NotFound();
            }

            return View(business);
        }

        // POST: Businesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var business = await _context.Business.FindAsync(id);
            _context.Business.Remove(business);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessExists(int id)
        {
            return _context.Business.Any(e => e.BusinessId == id);
        }
    }
}
