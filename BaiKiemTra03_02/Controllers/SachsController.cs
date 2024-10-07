using BaiKiemTra03_02.Data;
using BaiKiemTra03_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BaiKiemTra03_02.Controllers
{
    public class SachsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SachsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sachs
        public IActionResult Index()
        {
            var sachList = _context.Sachs.Include(s => s.TacGia).ToList();
            return View(sachList);
        }

        // GET: Sachs/Create
        public IActionResult Create()
        {
            ViewBag.TacGiaId = new SelectList(_context.TacGias, "TacGiaId", "TenTacGia");
            return View();
        }

        // POST: Sachs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Sachs.Add(sach);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Sách đã được thêm mới thành công!";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TacGiaId = new SelectList(_context.TacGias, "TacGiaId", "TenTacGia", sach.TacGiaId);
            return View(sach);
        }

        // GET: Sachs/Edit/5
        public IActionResult Edit(int id)
        {
            var sach = _context.Sachs.Find(id);
            if (sach == null)
            {
                return NotFound();
            }
            ViewBag.TacGiaId = new SelectList(_context.TacGias, "TacGiaId", "TenTacGia", sach.TacGiaId);
            return View(sach);
        }

        // POST: Sachs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Sachs.Update(sach);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Sách đã được cập nhật thành công!";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TacGiaId = new SelectList(_context.TacGias, "TacGiaId", "TenTacGia", sach.TacGiaId);
            return View(sach);
        }

        // GET: Sachs/Delete/5
        public IActionResult Delete(int id)
        {
            var sach = _context.Sachs.Include(s => s.TacGia).FirstOrDefault(s => s.SachId == id);
            if (sach == null)
            {
                return NotFound();
            }
            return View(sach);
        }

        // POST: Sachs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var sach = _context.Sachs.Find(id);
            if (sach == null)
            {
                return NotFound();
            }
            _context.Sachs.Remove(sach);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Sách đã được xóa thành công!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Sachs/Details/5
        public IActionResult Details(int id)
        {
            var sach = _context.Sachs.Include(s => s.TacGia).FirstOrDefault(s => s.SachId == id);
            if (sach == null)
            {
                return NotFound();
            }
            return View(sach);
        }
    }
}
