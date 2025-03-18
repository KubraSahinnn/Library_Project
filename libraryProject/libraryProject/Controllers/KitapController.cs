

using LibraryProject.Models;
using LibraryProject.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;

namespace LibraryProject.Controllers
{
	[Authorize(Roles =UserRoles.roleAdmin + UserRoles.roleYonetici)]
	public class KitapController : Controller
	{
		private readonly IKitapRepository _kR;
		//public readonly IWebHostEnvironment _webHostEnvironment;

		public readonly UygulamaDbContext _ugulamaDbContext;
		public KitapController(IKitapRepository context/*,IWebHostEnvironment webHostEnvironment*/)
		{
			_kR = context;
			//_webHostEnvironment = webHostEnvironment;
		}
		public IActionResult Index()
		{			
			List<Kitap> objKitapList = _kR.GetAll().ToList();
			return View(objKitapList);
		}
		public IActionResult Ekle()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Ekle(Kitap k,IFormFile? file)
		{

			if (ModelState.IsValid)
			{
				//string wwwRootPath = _webHostEnvironment.WebRootPath;
				//string kPath = Path.Combine(wwwRootPath, @"img");
				//using (var fileStream = new FileStream(Path.Combine(kPath, file.FileName), FileMode.Create))
				//{
				//	file.CopyTo(fileStream);
				//}
				//k.resimUrl = @"\img\" + file.FileName;

				_kR.Ekle(k);
				_kR.Save();
				
			}
			return RedirectToAction("Index", "Kitap");
		}
		public IActionResult Guncelle(int id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Kitap k = _kR.Get(x => x.Id == id);
			if (k == null)
			{
				return NotFound();
			}
			return View(k);
		}
		[HttpPost]
		public IActionResult Guncelle(Kitap k)
		{
			if (ModelState.IsValid)
			{
				_kR.Guncelle(k);
				_kR.Save();
				return RedirectToAction("Index", "Kitap");
			}
			else
			{
				return View();
			}
		}
		public IActionResult Sil(int id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Kitap k = _kR.Get(x => x.Id == id);

			if (k == null)
			{
				return NotFound();
			}
			return View(k);
		}
		[HttpPost, ActionName("Sil")]
		public IActionResult Sil(int? id)
		{
			Kitap k = _kR.Get(x => x.Id == id);

			if (k == null)
			{
				return NotFound();
			}
			_kR.Sil(k);
			_kR.Save();
			return RedirectToAction("Index", "Kitap");
		}
	}
}

