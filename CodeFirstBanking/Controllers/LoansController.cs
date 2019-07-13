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
    public class LoansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoansController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult BusTransfer()
        {

            Loan Loan = _context.Loan.Find(1);
            Business business = _context.Business.Find(1);

            TempData["BBalance"] = business.AccountBalance;
            TempData["BTemp"] = 0;
            business.AccountBalance = (int)TempData["BTemp"];

            TempData["LBalance"] = Loan.AccountBalance;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult BusTransfer(Loan loan, Business business)
        {
            if (ModelState.IsValid)
            {
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

                int withdrawamount = loan.AccountBalance;
                loan.AccountBalance = (int)TempData["LBalance"];
                loan.AccountBalance -= withdrawamount;
                _context.Entry(loan).State = EntityState.Modified;
                _context.LoanTrans.Add(new LoanTrans
                {
                    Time = DateTime.Now,
                    Amount = withdrawamount,
                    LoanId = loan.LoanId,
                    Type = "TransferSub"

                });
                _context.SaveChanges();

            }

            return View();

        }

        public ActionResult CheckTransfer()
        {

            Loan Loan = _context.Loan.Find(1);
            Checking checking = _context.Checking.Find(1);

            TempData["CBalance"] = checking.AccountBalance;
            TempData["CTemp"] = 0;
            checking.AccountBalance = (int)TempData["CTemp"];

            TempData["LBalance"] = Loan.AccountBalance;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CheckTransfer(Loan loan, Checking checking)
        {
            if (ModelState.IsValid)
            {
                int withdrawamount = loan.AccountBalance;
                loan.AccountBalance = (int)TempData["LBalance"];
                loan.AccountBalance -= withdrawamount;
                _context.Entry(loan).State = EntityState.Modified;
                _context.LoanTrans.Add(new LoanTrans
                {
                    Time = DateTime.Now,
                    Amount = withdrawamount,
                    LoanId = loan.LoanId,
                    Type = "TransferSub"

                });
                _context.SaveChanges();

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
            }

            return View();

        }

        public ActionResult PayLoan()
        {

            Loan loan = _context.Loan.Find(1);
            Console.WriteLine(loan.AccountBalance);

            TempData["Balance"] = loan.AccountBalance;
            TempData["Temp"] = 0;
            loan.AccountBalance = (int)TempData["Temp"];

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult PayLoan(Loan loan)
        {
            if (ModelState.IsValid)
            {
                int payamount = loan.AccountBalance;
                loan.AccountBalance += (int)TempData["Balance"];
                _context.Entry(loan).State = EntityState.Modified;
                _context.LoanTrans.Add(new LoanTrans
                {
                    Time = DateTime.Now,
                    Amount = payamount,
                    LoanId = loan.LoanId,
                    Type = "PayLoan"

                });

                _context.SaveChanges();
            }

            return View();

        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Loan.ToListAsync());
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // GET: Loans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanId,AccountBalance")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loan);
        }

        // GET: Loans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanId,AccountBalance")] Loan loan)
        {
            if (id != loan.LoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanExists(loan.LoanId))
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
            return View(loan);
        }

        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loan = await _context.Loan.FindAsync(id);
            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanExists(int id)
        {
            return _context.Loan.Any(e => e.LoanId == id);
        }
    }
}
