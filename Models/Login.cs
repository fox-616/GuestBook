using System.ComponentModel.DataAnnotations;

namespace GuestBook.Models
{
    public class Login
    {
        [Key]
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        [StringLength(10, ErrorMessage = "帳號最多10碼")]
        [RegularExpression("[A-Za-z][A-Za-z0-9]{4,9}",ErrorMessage ="帳號格式有誤")]
        public string Account { get; set; } = null!;

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        [StringLength(12)]
        [MinLength(8,ErrorMessage ="密碼最少8碼")]
        [MaxLength(12, ErrorMessage = "密碼最多12碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
