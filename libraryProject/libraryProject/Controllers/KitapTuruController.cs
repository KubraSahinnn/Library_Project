using LibraryProject.Models;
using LibraryProject.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LibraryProject.Controllers
{

    public class KitapTuruController : Controller
	{
		private readonly IKitapTuruRepository _kTR;
		public KitapTuruController(IKitapTuruRepository context)
		{
			_kTR = context;
		}
        [Authorize(Roles = "Yonetici,Admin,Kullanici")]
        public IActionResult Index()
		{
			List<kitapTuru> objKitapTuruList = _kTR.GetAll().ToList();
			return View(objKitapTuruList);
		}   
		[Authorize(Roles = "Yonetici,Admin")]
		public IActionResult Ekle()
		{
			return View();
		}
        [Authorize(Roles = "Yonetici,Admin")]
        [HttpPost]
		public IActionResult Ekle(kitapTuru kt)
		{
			if (ModelState.IsValid)
			{
				_kTR.Ekle(kt);
				_kTR.Save();//değişiklikleri ver tabanına aktarır
				return RedirectToAction("Index", "KitapTuru");
			}
			else
			{
				return View();
			}
		}
        [Authorize(Roles = "Yonetici,Admin")]
        public IActionResult Guncelle(int id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			kitapTuru? kt = _kTR.Get(x => x.Id == id);
			if (kt == null)
			{
				return NotFound();
			}
			return View(kt);
		}
		[HttpPost]
        [Authorize(Roles = "Yonetici,Admin")]
        public IActionResult Guncelle(kitapTuru kt)
		{
			if (ModelState.IsValid)
			{
				_kTR.Guncelle(kt);
				_kTR.Save();
				return RedirectToAction("Index", "KitapTuru");
			}
			else
			{
				return View();
			}
		}
        [Authorize(Roles = "Yonetici,Admin")]
        public IActionResult Sil(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			kitapTuru? kt = _kTR.Get(x => x.Id == id);

			if (kt == null)
			{
				return NotFound();
			}
			return View(kt);
		}
		[HttpPost,ActionName("Sil")]
        [Authorize(Roles = "Yonetici,Admin")]
        public IActionResult SilPost(int? id)
		{
			kitapTuru? kt = _kTR.Get(x => x.Id == id);

			if (kt==null)
			{
				return NotFound();
			}
			_kTR.Sil(kt);
			_kTR.Save();
			return RedirectToAction("Index", "KitapTuru");
		}
	}
}
