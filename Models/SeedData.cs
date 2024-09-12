using Microsoft.EntityFrameworkCore;

namespace GuestBook.Models
{




    public class SeedData
    {
        //(1)撰寫靜態方法 Initialize(IServiceProvider serviceProvider)
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //(2)撰寫Book及ReBook資料表內的初始資料程式
            //using 後續 release 空間
            using (GuestBookContext context = new GuestBookContext(serviceProvider.GetRequiredService<DbContextOptions<GuestBookContext>>()))
            {
                if (!context.Book.Any()) //如果資料庫沒有任何一筆資料，建立種子資料
                {

                    context.Book.AddRange(
                        new Book
                        {
                            Title = "刀劍神域第一季",
                            Description = "這超好看的啦!!!!!",
                            Photo = getFileBytes("wwwroot/SeedSourcePhoto/1.JPG"),
                            ImageType = "image/jpeg",
                            Author = "桐人",
                            TimeStamp = DateTime.Now
                        },
                        new Book
                        {
                            Title = "刀劍神域第二季",
                            Description = "期待續集~~~~",
                            Photo = getFileBytes("wwwroot/SeedSourcePhoto/2.JPG"),
                            ImageType = "image/jpeg",
                            Author = "靜香",
                            TimeStamp = DateTime.Now
                        },
                        new Book
                        {
                            Title = "刀劍神域第三季",
                            Description = "這一集好悲傷啊~~ 藍瘦香菇",
                            Photo = getFileBytes("wwwroot/SeedSourcePhoto/3.JPG"),
                            ImageType = "image/jpeg",
                            Author = "七瀨美雪",
                            TimeStamp = DateTime.Now
                        },
                         new Book
                         {
                             Title = "第一季後宮",
                             Description = "我喜歡結衣",
                             Photo = getFileBytes("wwwroot/SeedSourcePhoto/4.JPG"),
                             ImageType = "image/jpeg",
                             Author = "新堂功太郎",
                             TimeStamp = DateTime.Now
                         },
                         new Book
                         {
                             Title = "星爆氣流斬",
                             Description = "阿~~~~ 看我的星~~~爆~~~~~~~",
                             Photo = getFileBytes("wwwroot/SeedSourcePhoto/5.JPG"),
                             ImageType = "image/jpeg",
                             Author = "桐人本尊",
                             TimeStamp = DateTime.Now
                         });
                    context.SaveChanges();

                    context.ReBook.AddRange(
                        new ReBook
                        {
                            Description = "我也喜歡，迷上它了~~",
                            Author = "亞絲娜",
                            TimeStamp = DateTime.Now,
                            GId = 1
                        },
                        new ReBook
                        {
                            Description = "我都看三遍了~",
                            Author = "結衣",
                            TimeStamp = DateTime.Now,
                            GId = 1
                        },
                        new ReBook
                        {
                            Description = "在這個房間內，有一個人是犯人(推眼鏡)",
                            Author = "柯南",
                            TimeStamp = DateTime.Now,
                            GId = 2
                        },
                        new ReBook
                        {
                            Description = "你跑錯棚了吧~ 這裡是刀劍神域討論版勒",
                            Author = "小蘭",
                            TimeStamp = DateTime.Now,
                            GId = 2
                        },
                        new ReBook
                        {
                            Description = "誰叫我？",
                            Author = "索隆",
                            TimeStamp = DateTime.Now,
                            GId = 2
                        },
                        new ReBook
                        {
                            Description = "我不喜歡這集...T.T？",
                            Author = "結衣",
                            TimeStamp = DateTime.Now,
                            GId = 3
                        },
                        new ReBook
                        {
                            Description = "星爆超帥的啦~",
                            Author = "我才是桐人",
                            TimeStamp = DateTime.Now,
                            GId = 5
                        },
                        new ReBook
                        {
                            Description = "叫我做什麼？",
                            Author = "星爆",
                            TimeStamp = DateTime.Now,
                            GId = 5
                        },
                        new ReBook
                        {
                            Description = "蛤...？ 囧a",
                            Author = "索隆",
                            TimeStamp = DateTime.Now,
                            GId = 5
                        });
                    context.SaveChanges();
                }
            }


            //(3)撰寫getFileBytes，功能為將照片轉成二進位資料
            byte[] getFileBytes(string path)
            {
                FileStream file = new FileStream(path, FileMode.Open);

                byte[] filebytes;

                using (BinaryReader binaryreader = new BinaryReader(file))
                {
                    filebytes = binaryreader.ReadBytes((int)file.Length);
                }
                return filebytes;
            }
        }
    }
}
