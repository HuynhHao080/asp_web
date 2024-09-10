using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BaiTapKiemTra01.Models
{
    public class SanPhamViewModel
    {
        [Display(Name = "Tên sản phẩm")]
        public string TenSanPham { get; set; }

        [Display(Name = "Giá bán")]
        public decimal GiaBan { get; set; }

        [Display(Name = "Ảnh mô tả")]
        public string AnhMoTa { get; set; }

    }
}
