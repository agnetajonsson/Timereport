using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Timereport.Data;
using Timereport.Models;

namespace Timereport.Controllers
{
    public class OneUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OneUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OneUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.OneUser.ToListAsync());
        }

        // GET: OneUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oneUser = await _context.OneUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oneUser == null)
            {
                return NotFound();
            }

            return View(oneUser);
        }

        // GET: OneUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OneUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LoginTime,LogoutTime,Reason")] OneUser oneUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oneUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oneUser);
        }

        // GET: OneUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oneUser = await _context.OneUser.FindAsync(id);
            if (oneUser == null)
            {
                return NotFound();
            }
            return View(oneUser);
        }

        // POST: OneUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LoginTime,LogoutTime,Reason")] OneUser oneUser)
        {
            if (id != oneUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oneUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OneUserExists(oneUser.Id))
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
            return View(oneUser);
        }

        // GET: OneUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oneUser = await _context.OneUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oneUser == null)
            {
                return NotFound();
            }

            return View(oneUser);
        }

        // POST: OneUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oneUser = await _context.OneUser.FindAsync(id);
            _context.OneUser.Remove(oneUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OneUserExists(int id)
        {
            return _context.OneUser.Any(e => e.Id == id);
        }
    }
}
