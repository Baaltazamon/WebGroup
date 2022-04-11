using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebGroup.Models;

namespace WebGroup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Models.GolovinContext db = new GolovinContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutCollege()
        {
            return View();
        }
        public IActionResult Team()
        {
            List<Member> mem = db.Members.Where(c => c.Status != 9).ToList();
            List<StatusStudent> lstatus = db.StatusStudents.ToList();
             
            return View(Tuple.Create(mem, lstatus));
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Achievement()
        {
            return View();
        }
        public IActionResult Project()
        {
            return View();
        }
        public IActionResult News()
        {
            List<News> lnews = db.News.ToList();
            List<Member> lmem = db.Members.ToList();

            return View(Tuple.Create(lnews, lmem));
        }
        public IActionResult About()
        {
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
