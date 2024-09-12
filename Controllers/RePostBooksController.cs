using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuestBook.Models;

namespace GuestBook.Controllers
{
    public class RePostBooksController : Controller
    {
        private readonly GuestBookContext _context;

        public RePostBooksController(GuestBookContext context)
        {
            _context = context;
        }

        // GET: RePostBooks/Create
        public IActionResult Create(long GId)
        {
            //ViewData["GId"] = new SelectList(_context.Book, "GId", "Author");
            ViewData["GId"] = GId;

            return View();
        }

        // POST: RePostBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ReBook reBook)
        {
            reBook.TimeStamp = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(reBook);
                await _context.SaveChangesAsync();
                //3.5.9 修改RePostBooksController中的Create Action，使其Return JSON資料
                //return RedirectToAction("Display", "PostBooks", new {id=reBook.GId});
                return Json(reBook);
            }
            ViewData["GId"] = new SelectList(_context.Book, "GId", "Author", reBook.GId);
            //3.5.9 修改RePostBooksController中的Create Action，使其Return JSON資料
            //return View(reBook);
            return Json(reBook);
        }

        public IActionResult GetRebookByViewComponent(long id)
        {
            return ViewComponent("VCReBooks", new {gid = id});
        }


        private bool ReBookExists(long id)
        {
            return _context.ReBook.Any(e => e.RId == id);
        }
    }
}
