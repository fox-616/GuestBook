using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestBook.Models
{
    public class ReBook
    {
        [Key]
        public long RId { get; set; }

        [Display(Name = "回覆內容")]
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = null!;

        [Display(Name = "回覆人")]
        [Required(ErrorMessage = "必填")]
        [StringLength(10, ErrorMessage = "姓名最多10個字")]
        public string Author { get; set; } = null!;

        [Display(Name = "回覆時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm:ss}")]
        public DateTime TimeStamp { get; set; }

        //這是來自Book的外來鍵
        [ForeignKey("Book")]
        public long GId { get; set; }

        //與 Book 進行資料表的關連
        public virtual Book? Book { get; set; } = null!;
    }
}
