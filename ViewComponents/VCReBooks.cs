using GuestBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.ViewComponents
{
    public class VCReBooks : ViewComponent
    {
        private readonly GuestBookContext _context;

        public VCReBooks(GuestBookContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long gid)
        {
            var rebook = await _context.ReBook.Where(m => m.GId == gid).OrderByDescending(m => m.TimeStamp).ThenByDescending(m => m.RId).ToListAsync();

            return View(rebook);
        }

    }
}
