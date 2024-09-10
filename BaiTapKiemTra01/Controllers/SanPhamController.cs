using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace BaiTapKiemTra01.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BaiTap2()
        {
            var sanpham = new SanPhamViewModel()
            {
                TenSanPham = "Ảnh bàn ghế",
                GiaBan = 24,
                AnhMoTa = "/images/img-grid-2.jpg"
            };

            return View(sanpham);
        }
    }
}
