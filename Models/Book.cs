using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GuestBook.Models
{
    public class Book
    {
        [Key]
        public long GId { get; set; }

        [Display(Name = "主旨")]
        [Required(ErrorMessage ="必填")]
        [StringLength(30,ErrorMessage ="主旨最多30個字")]
        public string Title { get; set; } = null!;

        [Display(Name = "內容")]
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = null!;

        [Display(Name = "留言人")]
        [Required(ErrorMessage = "必填")]
        [StringLength(20, ErrorMessage = "姓名最多20個字")]
        public string Author { get; set; } = null!;

        [Display(Name = "留言時間")]
        [Required]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd hh:mm:ss}")]
        public DateTime TimeStamp { get; set; }

        [Display(Name = "照片")]
        public byte[]? Photo{ get; set; }

        [HiddenInput]
        public string? ImageType { get; set; }

        //與 ReBooks 進行資料表的關連
        public virtual List<ReBook>? ReBooks { get; set; }

    }
}
