using Microsoft.EntityFrameworkCore;

namespace GuestBook.Models
{
    //撰寫 GuestBookContext 的內容
    //繼承DbContext類別       
    public class GuestBookContext : DbContext
    {
        //撰寫建構子︰使用依賴注入的方式
        public GuestBookContext(DbContextOptions<GuestBookContext> options)
        : base(options)
        {

        }


        //描述資料庫裡面的資料表︰建立 virtual 資料
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<ReBook> ReBook { get; set; }
        public virtual DbSet<Login> Login { get; set; }

    }
}
