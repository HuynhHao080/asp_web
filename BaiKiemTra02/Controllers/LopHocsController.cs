using BaiKiemTra02.Data;
using BaiKiemTra02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra02.Controllers
{
    public class LopHocsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LopHocsController(ApplicationDbContext db)
        {
            _db = db;
        }
        //ShowDS
        [HttpGet]
        public IActionResult Index()
        {
            var listLopHoc = _db.LopHocs.ToList();  
            return View(listLopHoc);
        }
        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                _db.LopHocs.Add(lopHoc);
                _db.SaveChanges();

                // Lưu thông báo vào TempData
                TempData["SuccessMessage"] = "Lớp học đã được thêm mới thành công!";

                return RedirectToAction(nameof(Index));
            }
            return View(lopHoc);
        }
        //Delete

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var lophoc = _db.LopHocs.Find(id);
            if (lophoc == null)
            {
                return NotFound();
            }

            return View(lophoc);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var lophoc = _db.LopHocs.Find(id);
            if (lophoc == null)
            {
                return NotFound();
            }

            _db.LopHocs.Remove(lophoc);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        //Edit
        // Phương thức GET để hiển thị form chỉnh sửa
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var lopHoc = _db.LopHocs.Find(id); // Lấy lớp học theo ID
            if (lopHoc == null)
            {
                return NotFound(); // Nếu không tìm thấy, trả về lỗi 404
            }
            return View(lopHoc); // Trả về view chỉnh sửa với dữ liệu lớp học
        }

        // Phương thức POST để cập nhật thông tin lớp học
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LopHoc lopHoc)
        {
            if (ModelState.IsValid) // Kiểm tra tính hợp lệ của dữ liệu
            {
                _db.Update(lopHoc); // Cập nhật lớp học
                _db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                TempData["SuccessMessage"] = "Lớp học đã được cập nhật thành công!"; // Thông báo thành công
                return RedirectToAction(nameof(Index)); // Chuyển hướng về trang danh sách
            }
            return View(lopHoc); // Nếu không hợp lệ, trả về form chỉnh sửa với thông tin lớp học
        }
        //Detail
        // Phương thức GET để hiển thị thông tin chi tiết lớp học
        [HttpGet]
        public IActionResult Details(int id)
        {
            var lopHoc = _db.LopHocs.Find(id); // Lấy lớp học theo ID
            if (lopHoc == null)
            {
                return NotFound(); // Nếu không tìm thấy, trả về lỗi 404
            }
            return View(lopHoc); // Trả về view chi tiết với dữ liệu lớp học
        }

    }
}
