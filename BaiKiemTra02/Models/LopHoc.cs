using System.ComponentModel.DataAnnotations;
namespace BaiKiemTra02.Models
{
    public class LopHoc
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên lớp học không được để trống.")]
        [StringLength(50)]
        public string TenLopHoc { get; set; }

        [Required(ErrorMessage = "Năm nhập học không được để trống.")]
        [Range(1900, 2100, ErrorMessage = "Năm nhập học phải nằm trong khoảng từ 1900 đến 2100.")]
        public int? NamNhapHoc { get; set; }

        [Required(ErrorMessage = "Năm ra trường không được để trống.")]
        [Range(1900, 2100, ErrorMessage = "Năm ra trường phải nằm trong khoảng từ 1900 đến 2100.")]
        public int? NamRaTruong { get; set; }

        [Required(ErrorMessage = "Số lượng sinh viên không được để trống.")]
        [Range(1, 1000, ErrorMessage = "Số lượng sinh viên phải từ 1 đến 1000.")]
        public int? SoLuongSinhVien { get; set; }
    }



}
