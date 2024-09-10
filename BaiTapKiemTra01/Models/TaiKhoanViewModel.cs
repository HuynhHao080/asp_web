using System.ComponentModel.DataAnnotations;

namespace BaiTapKiemTra01.Models
{
    
    public class TaiKhoanViewModel
    {
        [Required(ErrorMessage = "Tên tài khoản không được để trống")]
        [Display(Name = "Tên tài khoản")]
        public string TenTaiKhoan { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [Display(Name = "Họ và tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Tuổi không được để trống")]
        [Range(1, 120, ErrorMessage = "Tuổi phải nằm trong khoảng từ 1 đến 120")]
        [Display(Name = "Tuổi")]
        public int? Tuoi { get; set; } // Chú ý: Sử dụng int? (nullable int) thay vì int
    }

}
