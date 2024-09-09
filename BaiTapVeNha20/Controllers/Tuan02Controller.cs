using Microsoft.AspNetCore.Mvc;

namespace BaiTapVeNha20.Controllers
{
	public class Tuan02Controller : Controller
	{
		public IActionResult Index()
		{
			ViewBag.HoTen = "Huỳnh Nhựt Hào";
			ViewBag.MSSV = "1822040542";
			ViewBag.Nam = 2024;

			// Trả về View
			return View();
		}
		public IActionResult MayTinh(double a, double b, string pheptinh)
		{
			double kq = 0;
			string thongbao = "";
			switch (pheptinh)
			{
				case "cong":
					kq = a + b;
					thongbao = $"{a} + {b} = {kq}";
					break;
                case "tru":
                    kq = a - b;
                    thongbao = $"{a} - {b} = {kq}";
                    break;
                case "nhan":
                    kq = a * b;
                    thongbao = $"{a} x {b} = {kq}";
                    break;
                case "chia":
                    if (b != 0)
                    {
                        kq = a / b;
                        thongbao = $"{a} / {b} = {kq}";
                    }
                    else
                    {
                        thongbao = "Lỗi: Không thể chia cho 0!";
                    }
                    break;
                default:
                    thongbao = "Lỗi: Phép tính không hợp lệ!";
                    break;
            }
            ViewBag.KetQua = kq;
            ViewBag.ThongBao = thongbao;

            // Trả về View MayTinh
            return View();
        }
        public IActionResult Profile()
        {
            ViewBag.HoTen = "Huỳnh Nhựt Hào";
            ViewBag.MSSV = "1822040542";
            ViewBag.Nam = 2024;
            // Trả về View Profile
            return View();
        }

    }
}
