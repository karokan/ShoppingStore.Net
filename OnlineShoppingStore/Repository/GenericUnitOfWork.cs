using OnlineShoppingStore.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Repository
{
    public class GenericUnitOfWork:IDisposable
    {
        private dbSmartphoneShoppingStoreEntities DBEntity = new dbSmartphoneShoppingStoreEntities();

        public IRepository<Table_EntityType> GetRepositoryInstance<Table_EntityType>() where Table_EntityType: class
        {
            return new GenericRepository<Table_EntityType>(DBEntity);
        }

        public void SaveChanges()
        {
            DBEntity.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DBEntity.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
    }
}