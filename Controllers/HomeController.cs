using GuestBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GuestBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly GuestBookContext _context;

        public HomeController(ILogger<HomeController> logger, GuestBookContext context)
        {

            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = _context.Book.Where(b => b.Photo != null).OrderByDescending(b => b.TimeStamp).ThenByDescending(b => b.GId).Take(10);

            return View(await result.ToListAsync());
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
