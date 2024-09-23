using BaiTap07.Data;
using BaiTap07.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap07.Controllers
{
	public class TheLoaiController : Controller
	{
		public readonly ApplicationDbContext _db;
		public TheLoaiController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			var theloai = _db.TheLoai.ToList();
			ViewBag.TheLoai = theloai;
			return View();
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(TheLoai theloai)
		{
			if(ModelState.IsValid)
			{
				_db.TheLoai.Add(theloai);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
			var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }

        [HttpPost]
        public IActionResult Edit(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoai.Update(theloai);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }

            return View(theloai);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.TheLoai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }

            _db.TheLoai.Remove(theloai);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }
		public IActionResult Details(int? id, DateTime? dateBefore)
		{
			var query = _db.TheLoai.AsQueryable();

			if (id.HasValue)
			{
				query = query.Where(tl => tl.Id > id.Value);
			}

			if (dateBefore.HasValue)
			{
				query = query.Where(tl => tl.DateCreated < dateBefore.Value);
			}

			var result = query.ToList();

			return View(result);
		}
        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var theloai = _db.TheLoai.Where(tl => tl.Name.Contains(searchString)).ToList();
				ViewBag.TheLoai = theloai;
                ViewBag.SearchString = searchString;
			}
            else
            {
                var theloai = _db.TheLoai.ToList();
				ViewBag.TheLoai = theloai;
			}
            return View("Index");
        }

	}
}
