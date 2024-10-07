using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiKiemTra03_02.Models
{
    public class Sach
    {
        [Key]
        [Required(ErrorMessage = "Mã sách không được để trống.")]
        public int SachId { get; set; }

        [Required(ErrorMessage = "Tiêu đề sách không được để trống.")]
        [StringLength(100, ErrorMessage = "Tiêu đề sách không được vượt quá 100 ký tự.")]
        public string TieuDe { get; set; }

        [Range(1500, 2100, ErrorMessage = "Năm xuất bản không hợp lệ.")]
        public int NamXuatBan { get; set; }

        [Required(ErrorMessage = "Mã tác giả không được để trống.")]
        public int TacGiaId { get; set; }

        [StringLength(50, ErrorMessage = "Thể loại không được vượt quá 50 ký tự.")]
        public string TheLoai { get; set; }

        // Khóa ngoại liên kết với tác giả
        [ForeignKey("TacGiaId")]
        [ValidateNever]
        public TacGia TacGia { get; set; }
    }
}
