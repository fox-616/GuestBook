﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuestBook.Models;

namespace GuestBook.Controllers
{
    public class BooksController : Controller
    {
        private readonly GuestBookContext _context;

        public BooksController(GuestBookContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Book.OrderByDescending(b => b.TimeStamp).ThenByDescending(b => b.GId).ToListAsync());
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.GId == id);

            //var rebook = await _context.ReBook.Where(m => m.GId == id).ToListAsync();

            //ViewData["rebook"] = rebook;

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //在BooksController內增加刪除回覆留言Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReBook(long id)
        {
            
            var reBook = await _context.ReBook.FindAsync(id);
            if (reBook != null)
            {
                _context.ReBook.Remove(reBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Delete",new {id=reBook.GId});
        }

        private bool BookExists(long id)
        {
            return _context.Book.Any(e => e.GId == id);
        }

        public async Task<FileContentResult> GetImage(long gid)
        {
            var book = await _context.Book.FindAsync(gid);

            if (book == null)
            {
                return null;
            }

            return File(book.Photo, book.ImageType);
        }

    }
}
