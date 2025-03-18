using LibraryProject.Utility;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace LibraryProject.Models
{
    public class KitapTuruRepository : Repository<kitapTuru>, IKitapTuruRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public KitapTuruRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(kitapTuru kt)
        {
            _uygulamaDbContext.Update(kt);
        }

        public void Save()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
