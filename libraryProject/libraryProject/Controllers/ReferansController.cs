using LibraryProject.Models;
using LibraryProject.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Controllers
{
	public class ReferansController : Controller
	{
		private readonly IReferansRepository _rR;
		private readonly IKitapTuruRepository _kTR;

		public readonly UygulamaDbContext _ugulamaDbContext;
		public readonly Referans r;
		public ReferansController(IReferansRepository context, IKitapTuruRepository kTR)
		{
			_rR = context;
			_kTR = kTR;
		}
        [Authorize(Roles = "Yonetic,Admin,Kullanici")]
        public IActionResult Index()
		{
			List<Referans> objReferansList = _rR.GetAll().ToList();
			return View(objReferansList);
		}
        [Authorize(Roles = "Yonetici,Admin")]
        public IActionResult Ekle()
		{
			return View();
		}
        [Authorize(Roles = "Yonetici,Admin")]
        [HttpPost]
		public IActionResult Ekle(Referans r)
		{
			
			if (ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(x => x.Errors);
				if(errors.Any())
				{
					foreach(var error in errors)
					{
						Console.WriteLine(error.ErrorMessage);
					}
				}
				_rR.Ekle(r);
				_rR.Save();
				return RedirectToAction("Index", "Referans");
			}
			
			return View();
		}
        [Authorize(Roles = "Yonetici,Admin")]
        public IActionResult Guncelle(int id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Referans r = _rR.Get(x => x.Id == id);
			if (r == null)
			{
				return NotFound();
			}
			return View(r);
		}
		[HttpPost]
        [Authorize(Roles = "Yonetici,Admin")]
        public IActionResult Guncelle(Referans r)
		{
			if (ModelState.IsValid)
			{
				_rR.Guncelle(r);
				_rR.Save();
				return RedirectToAction("Index", "Referans");
			}
			else
			{
				return View();
			}
		}
        [Authorize(Roles = "Yonetici,Admin")]
        public IActionResult Sil(int id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Referans r = _rR.Get(x => x.Id == id);

			if (r == null)
			{
				return NotFound();
			}
			return View(r);
		}
        [Authorize(Roles = "Yonetici,Admin")]
        [HttpPost, ActionName("Sil")]
		public IActionResult Sil(int? id)
		{
			Referans r = _rR.Get(x => x.Id == id);

			if (r == null)
			{
				return NotFound();
			}
			_rR.Sil(r);
			_rR.Save();
			return RedirectToAction("Index", "Referans");
		}
	}
}
