namespace LibraryProject.Models
{
	public interface IReferansRepository:IRepository<Referans>
	{
		void Guncelle(Referans r);
		void Save();
	}
}
