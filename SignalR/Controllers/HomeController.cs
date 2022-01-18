using Microsoft.AspNetCore.Mvc;
using SignalR.DAL;
using SignalR.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SignalR.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.User = User.Identity.Name;
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

/*        public async Task<IActionResult> Status(AppUser appUser)
        {
*//*            var userStatus = _context.
            return View();*//*
        }*/
    }
}
