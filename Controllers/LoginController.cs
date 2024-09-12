using GuestBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GuestBook.Controllers
{
    public class LoginController : Controller
    {

        private readonly GuestBookContext _context;

        public LoginController(GuestBookContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (login == null)
            {
                return View();
            }

            var result = await _context.Login.Where(m => m.Account == login.Account && m.Password == login.Password).FirstOrDefaultAsync();

            //如果帳密不正確,回到登入頁面,並告知帳密錯誤
            if (result == null)
            {
                ViewData["Error"] = "帳號或密碼錯誤";
                return View();
            }
            else            //如果帳密正確,導入後台頁面
            {
                HttpContext.Session.SetString("Manager", JsonConvert.SerializeObject(login));

                return RedirectToAction("Index", "Books");
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Manager");

            return RedirectToAction("Index", "Home");

            //return View();
        }
    }
}
