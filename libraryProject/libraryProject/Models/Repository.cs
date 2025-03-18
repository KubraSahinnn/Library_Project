using LibraryProject.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryProject.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UygulamaDbContext _uygulamaDbContext;
        internal DbSet<T> dbSet;
        public Repository(UygulamaDbContext uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
            this.dbSet=_uygulamaDbContext.Set<T>();
		}

		public void AralıkSil(IEnumerable<T> entities)
		{
		    dbSet.RemoveRange(entities);
		}
		public void Ekle(T entity)
		{
    		dbSet.Add(entity);
            _uygulamaDbContext.SaveChanges();
		}
		

        public T Get(Expression<Func<T, bool>> filtre)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filtre);
            return query.FirstOrDefault();
        }

        
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Sil(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
