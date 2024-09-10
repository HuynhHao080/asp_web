using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace BaiTapKiemTra01.Controllers
{
    public class SanPhamController : Controller
    {
        [HttpGet]
        public IActionResult CreateSanPham()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSanPham(SanPhamViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.AnhMoTaFile != null && model.AnhMoTaFile.Length > 0)
                {
                    var fileName = Path.GetFileName(model.AnhMoTaFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.AnhMoTaFile.CopyToAsync(stream);
                    }

                    // Cập nhật đường dẫn ảnh vào ViewModel
                    model.AnhMoTa = "/images/" + fileName;
                }

                // Chuyển dữ liệu đến View 'BaiTap2'
                return View("BaiTap2", model);
            }

            // Nếu model không hợp lệ, quay lại View CreateSanPham
            return View(model);
        }
    }
}
