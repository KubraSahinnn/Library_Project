using LibraryProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Utility
{
	public class UygulamaDbContext:IdentityDbContext
	{
		public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }
		UygulamaDbContext _uygulamaDbContext;
		public DbSet<kitapTuru> KitapTurleri { get; set; }
		public DbSet<Kitap> Kitaplar {  get; set; }
		public DbSet<Referans> Referans { get; set; }

		
	}
}
