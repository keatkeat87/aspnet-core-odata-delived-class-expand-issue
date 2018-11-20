using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ODataDelivedExpandIssue.Models;

namespace ODataDelivedExpandIssue.Controllers
{
    public class HomeController : Controller
    {
        private AccountContext Db;
        public HomeController(
            AccountContext db 
        ) {
            Db = db;
        }

        public IActionResult Index()
        {
            Db.Users.Add(new User
            {
                Username = "Derrick",
                Password = "password",
                Characters = new List<Character>
                {
                    new Admin { Position = "Manager" },
                    new Member { VipLevel = 1 }
                }
            });
            Db.SaveChanges();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
