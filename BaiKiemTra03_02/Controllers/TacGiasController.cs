using BaiKiemTra03_02.Data;
using BaiKiemTra03_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra03_02.Controllers
{
    public class TacGiasController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TacGiasController(ApplicationDbContext db)
        {
            _db = db;
        }
        //ShowDS
        [HttpGet]
        public IActionResult Index()
        {
            var listTacGia = _db.TacGias.ToList();
            return View(listTacGia);
        }
        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TacGia TacGia)
        {
            if (ModelState.IsValid)
            {
                _db.TacGias.Add(TacGia);
                _db.SaveChanges();

                // Lưu thông báo vào TempData
                TempData["SuccessMessage"] = "Lớp học đã được thêm mới thành công!";

                return RedirectToAction(nameof(Index));
            }
            return View(TacGia);
        }
        //Delete

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var TacGia = _db.TacGias.Find(id);
            if (TacGia == null)
            {
                return NotFound();
            }

            return View(TacGia);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var TacGia = _db.TacGias.Find(id);
            if (TacGia == null)
            {
                return NotFound();
            }

            _db.TacGias.Remove(TacGia);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        //Edit
        // Phương thức GET để hiển thị form chỉnh sửa
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var TacGia = _db.TacGias.Find(id); // Lấy lớp học theo ID
            if (TacGia == null)
            {
                return NotFound(); // Nếu không tìm thấy, trả về lỗi 404
            }
            return View(TacGia); // Trả về view chỉnh sửa với dữ liệu lớp học
        }

        // Phương thức POST để cập nhật thông tin lớp học
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TacGia TacGia)
        {
            if (ModelState.IsValid) // Kiểm tra tính hợp lệ của dữ liệu
            {
                _db.Update(TacGia); // Cập nhật lớp học
                _db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                TempData["SuccessMessage"] = "Lớp học đã được cập nhật thành công!"; // Thông báo thành công
                return RedirectToAction(nameof(Index)); // Chuyển hướng về trang danh sách
            }
            return View(TacGia); // Nếu không hợp lệ, trả về form chỉnh sửa với thông tin lớp học
        }
        //Detail
        // Phương thức GET để hiển thị thông tin chi tiết lớp học
        [HttpGet]
        public IActionResult Details(int id)
        {
            var TacGia = _db.TacGias.Find(id); // Lấy lớp học theo ID
            if (TacGia == null)
            {
                return NotFound(); // Nếu không tìm thấy, trả về lỗi 404
            }
            return View(TacGia); // Trả về view chi tiết với dữ liệu lớp học
        }
    }
}
