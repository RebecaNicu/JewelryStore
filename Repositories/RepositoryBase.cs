using JewelryStore.Context;
using JewelryStore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JewelryStore.Repositories
{
        public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
        {
            protected JewelryStoreContext JewelryStoreContext   { get; set; }

            public RepositoryBase(JewelryStoreContext jewelryStore)
            {
                this.JewelryStoreContext = jewelryStore;
            }

            public IQueryable<T> FindAll()
            {
                return this.JewelryStoreContext.Set<T>().AsNoTracking();
            }

            public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
            {
                return this.JewelryStoreContext.Set<T>().Where(expression).AsNoTracking();
            }

            public void Create(T entity)
            {
                this.JewelryStoreContext.Set<T>().Add(entity);
            }

            public void Update(T entity)
            {
                this.JewelryStoreContext.Set<T>().Update(entity);
            }

            public void Delete(T entity)
            {
                this.JewelryStoreContext.Set<T>().Remove(entity);
            }
        }
}
