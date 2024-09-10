using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class AccountController : Controller
    {
        // Hiển thị form đăng ký
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        // Xử lý dữ liệu từ form đăng ký
        [HttpPost]
        public IActionResult DangKy(TaiKhoanViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Xử lý logic đăng ký (ví dụ lưu vào cơ sở dữ liệu)
                ViewBag.TenTaiKhoan = model.TenTaiKhoan;
                ViewBag.MatKhau = model.MatKhau;
                ViewBag.HoTen = model.HoTen;
                ViewBag.Tuoi = model.Tuoi;
                return View("DangKyThanhCong");
            }

            // Nếu dữ liệu không hợp lệ, quay lại form đăng ký
            return View(model);
        }

        // Trang thông báo đăng ký thành công
        public IActionResult DangKyThanhCong()
        {
            return View();
        }
    }
}
