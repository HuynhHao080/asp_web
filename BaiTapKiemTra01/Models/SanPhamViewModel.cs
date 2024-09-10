using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BaiTapKiemTra01.Models
{
    public class SanPhamViewModel
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [Display(Name = "Tên sản phẩm")]
        public string TenSanPham { get; set; }

        [Required(ErrorMessage = "Giá bán không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá bán phải là số dương")]
        [Display(Name = "Giá bán")]
        public decimal GiaBan { get; set; }

        // Sử dụng string để chứa đường dẫn ảnh
        [Display(Name = "Ảnh mô tả")]
        public string AnhMoTa { get; set; }

        // Tệp ảnh gốc
        public IFormFile AnhMoTaFile { get; set; }
    }
}
