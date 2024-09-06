using BaiTap05.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap05.Controllers
{
    public class TheLoaiController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ngay = "Ngày 30";
            ViewBag.Thang = "Tháng 4";
            ViewData["Nam"] = "Năm 1945";
            return View();
        }
        public IActionResult Index2()
        {
            var theloai = new TheLoaiViewModel
            {
                Id = 1822040542,
                Name = "Huỳnh Nhựt Hào",
                Status = "Đang học"
            };
            return View(theloai);   
        }
    }
}
