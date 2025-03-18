namespace LibraryProject.Models
{
    public interface IKitapTuruRepository:IRepository<kitapTuru>
    {
        void Guncelle(kitapTuru kt);
        void Save();
    }
}
