using System.Linq.Expressions;

namespace LibraryProject.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filtre);
        void Ekle(T entity);
        void Sil(T entity);
        void AralıkSil(IEnumerable<T> entities);
    }
}
