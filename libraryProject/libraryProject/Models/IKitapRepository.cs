namespace LibraryProject.Models
{
    public interface IKitapRepository:IRepository<Kitap>
    {
        void Guncelle(Kitap k);
        void Save();
    }
}
