using LibraryProject.Utility;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace LibraryProject.Models
{
    public class KitapRepository : Repository<Kitap>, IKitapRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public KitapRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Kitap k)
        {
            _uygulamaDbContext.Update(k);
        }
        public void Save()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
