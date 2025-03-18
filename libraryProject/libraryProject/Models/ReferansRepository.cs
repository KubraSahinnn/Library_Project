using LibraryProject.Utility;

namespace LibraryProject.Models
{
	public class ReferansRepository:Repository<Referans>, IReferansRepository
	{
		private UygulamaDbContext _uygulamaDbContext;
		public ReferansRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
		{
			_uygulamaDbContext = uygulamaDbContext;
		}
		public void Guncelle(Referans r)
		{
			_uygulamaDbContext.Update(r);
		}

		public void Save()
		{
			_uygulamaDbContext.SaveChanges();
		}
	}
}
