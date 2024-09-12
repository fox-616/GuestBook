using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuestBook.Models;
using System.IO;

namespace GuestBook.Controllers
{
    public class PostBooksController : Controller
    {
        private readonly GuestBookContext _context;

        public PostBooksController(GuestBookContext context)
        {
            _context = context;
        }

        // GET: PostBooks
        public async Task<IActionResult> Index()
        {

            var book = _context.Book.OrderByDescending(b=>b.TimeStamp).ThenByDescending(b=>b.GId);

            //var book = await _context.Book.ToListAsync();


            return View(await book.ToListAsync());
        }

        // GET: PostBooks/Details/5
        public async Task<IActionResult> Display(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.GId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: PostBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book, IFormFile? uploadPhoto)
        {
            //上傳照片的處理
            if (uploadPhoto != null)
            {
                if (uploadPhoto.ContentType != "image/jpeg" && uploadPhoto.ContentType != "image/png")
                {
                    ViewData["Message"] = "請上傳jpg或png格式的檔案!!";
                    return View(book);
                }

                //把檔案轉成二進位資料,並放入byte[]
                var mem = new MemoryStream();

                uploadPhoto.CopyTo(mem);

                book.Photo = mem.ToArray();
                book.ImageType = uploadPhoto.ContentType;

            }

            book.TimeStamp = DateTime.Now;


            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        
        private bool BookExists(long id)
        {
            return _context.Book.Any(e => e.GId == id);
        }

        public IActionResult ExceptionTest()
        {
            int a = 0;
            int s = 100 / a;
            return View();
        }

    }
}
