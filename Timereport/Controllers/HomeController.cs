using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Timereport.Data;
using Timereport.Models;



namespace Timereport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        ////Create an Admin
        //public async Task<IActionResult> Create([Bind("Id,UserId")] UserId userId)
        //{
        //     _context = context;
        //    if(_context.Count == 0)

        //    var identityResult = await async
        //    var admin = "Admin@Lexicon.se";
        //    var password = "Abc123!";
        //    var admin = "";

        //    var user = new IdentityUser
        //    {

        //    };

        //    _context.Add(oneUser);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //Save the LoginTime
        public async Task<IActionResult> LoginTime()
        {
            var reason = "";
            var userId = User.Identity.Name;

            var serverTime = DateTime.Now;
            if (serverTime.Hour > 9)
            {
                reason = "Late arrival";
            }
            else
            {
                reason = "";
            }

            var oneUser = new OneUser
            {
                LoginTime = DateTime.Now,
                Reason = reason,
                UserId = userId

            };

            _context.Add(oneUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Save the LogoutTime 
        public async Task<IActionResult> LogoutTime()
        {
            var reason = "";
            var userId = User.Identity.Name;

            var serverTime = DateTime.Now;
            if (serverTime.Hour < 16)
            {
                reason = "Early leaving";
            }
            else 
            {
                reason = "";
            }

            var oneUser = new OneUser
            {
                 LogoutTime = DateTime.Now,
                 Reason = reason,
                 UserId = userId
            };

            _context.Add(oneUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
