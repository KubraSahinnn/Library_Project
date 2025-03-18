using Microsoft.AspNetCore.Http;

namespace LibraryProject.Models
{
	public class ReferansViewModel
	{
		public Referans Referans{ get; set; }
		public IFormFile fotograf { get; set; }
	}
}
