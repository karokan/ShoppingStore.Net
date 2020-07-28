using OnlineShoppingStore.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace OnlineShoppingStore.Repository
{
    public class GenericRepository<Table_Entity> : IRepository<Table_Entity> where Table_Entity : class
    {
        DbSet<Table_Entity> _dbSet;

        private dbSmartphoneShoppingStoreEntities _DBEntity;

        public GenericRepository(dbSmartphoneShoppingStoreEntities DBEntity)
        {
            _DBEntity = DBEntity;
            _dbSet = _DBEntity.Set<Table_Entity>();
        }

        public IEnumerable<Table_Entity> GetProduct()
        {
            return _dbSet.ToList();
        }

  
        public void Add(Table_Entity entity)
        {
            _dbSet.Add(entity);
            _DBEntity.SaveChanges();
        }

        public int GetAllrecordCount()
        {
            return _dbSet.Count();
        }

        public IEnumerable<Table_Entity> GetAllRecords()
        {
            return _dbSet.ToList();
        }

        public IQueryable<Table_Entity> GetAllRecordsIQueryable()
        {
            return _dbSet;
        }

        public Table_Entity GetFirstorDefault(int recordId)
        {
            return _dbSet.Find(recordId);
        }

        public Table_Entity GetFirstorDefaultByParameter(Expression<Func<Table_Entity, bool>> wherePredict)
        {
            return _dbSet.Where(wherePredict).FirstOrDefault();
        }

        public IEnumerable<Table_Entity> GetListParameter(Expression<Func<Table_Entity, bool>> wherePredict)
        {
            return _dbSet.Where(wherePredict).ToList();
        }

        public IEnumerable<Table_Entity> GetResultBySqlProcedure(string query, params object[] parameters)
        {
            if(parameters != null)
            {
                return _DBEntity.Database.SqlQuery<Table_Entity>(query, parameters).ToList();
            }else
            {
                return _DBEntity.Database.SqlQuery<Table_Entity>(query).ToList();
            }
        }

        public void InactiveAndDeleteMarkByWhereClause(Expression<Func<Table_Entity, bool>> wherePredict, Action<Table_Entity> ForEachPredict)
        {
            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        public void Remove(Table_Entity entity)
        {
            if (_DBEntity.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public void RemovebyWhereClause(Expression<Func<Table_Entity, bool>> wherePredict)
        {
            Table_Entity entity = _dbSet.Where(wherePredict).FirstOrDefault();
            Remove(entity);
        }

        public void RemoveRangeBywhereClause(Expression<Func<Table_Entity, bool>> wherePredict)
        {
            List<Table_Entity> entity = _dbSet.Where(wherePredict).ToList();
            foreach(var ent in entity)
            {
                Remove(ent);
            }
        }

        public void Update(Table_Entity entity)
        {
            _dbSet.Attach(entity);
            _DBEntity.Entry(entity).State = EntityState.Modified;
            _DBEntity.SaveChanges();
        }

        public void UpdateByWhereClause(Expression<Func<Table_Entity, bool>> wherePredict, Action<Table_Entity> ForEachPredict)
        {
            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        public IEnumerable<Table_Entity> GetRecordsToShow(int PageNumber, int PageSize, int CurrentPage, Expression<Func<Table_Entity, bool>> wherePredict, Expression<Func<Table_Entity, int>> orderByPredict)
        {
            if (wherePredict != null)
            {
                return _dbSet.OrderBy(orderByPredict).Where(wherePredict).ToList();
            }
            else
            {
                return _dbSet.OrderBy(orderByPredict).ToList();
            }
        }
    }
}