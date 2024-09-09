using BaiTap06.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap06.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy(TaiKhoanViewModel taiKhoan)
        {
            return View(taiKhoan);
        }
    }
}
