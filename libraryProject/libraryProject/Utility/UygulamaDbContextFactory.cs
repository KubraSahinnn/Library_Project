using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibraryProject.Utility
{
	public class UygulamaDbContextFactory : IDesignTimeDbContextFactory<UygulamaDbContext>
	{
		public UygulamaDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder=new DbContextOptionsBuilder<UygulamaDbContext>();
			optionsBuilder.UseSqlServer("Server=DESKTOP-GPOGES2\\MSSQLSERVER02;Database=LibraryVeriTabani(1.2);Trusted_Connection=True;TrustServerCertificate=True");
			return new UygulamaDbContext(optionsBuilder.Options);	
		}
	}
}
