using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_02.Models
{
    public class TacGia
    {
        [Key]
        [Required(ErrorMessage = "Mã tác giả không được để trống.")]
        public int TacGiaId { get; set; }

        [Required(ErrorMessage = "Tên tác giả không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên tác giả không được vượt quá 100 ký tự.")]
        public string TenTacGia { get; set; }

        [StringLength(50, ErrorMessage = "Quốc tịch không được vượt quá 50 ký tự.")]
        public string QuocTich { get; set; }

        [Range(1800, 2100, ErrorMessage = "Năm sinh không hợp lệ.")]
        public int NamSinh { get; set; }
    }
}
