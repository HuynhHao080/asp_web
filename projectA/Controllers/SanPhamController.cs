﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projectA.Data;
using projectA.Models;

namespace projectA.Controllers
{
	[Area("Admin")]
	public class SanPhamController : Controller
	{
		private readonly ApplicationDbContext _db;
		public SanPhamController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();	
			return View(sanpham);
		}
		[HttpGet]
		public IActionResult Upsert(int id)
		{
			SanPham sanpham = new SanPham();
			IEnumerable<SelectListItem> dstheloai = _db.TheLoai.Select(
				item => new SelectListItem
				{
					Value = item.Id.ToString(),
					Text = item.Name
				});
			ViewBag.DSTheLoai = dstheloai;
			if(id == 0)
			{
				return View(sanpham);
			}
			else
			{
				sanpham = _db.SanPham.Include("TheLoai").FirstOrDefault(sp =>sp.Id == id);
				return View(sanpham);
			}
		}
	}
}
