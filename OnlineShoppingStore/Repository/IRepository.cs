using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace OnlineShoppingStore.Repository
{
    public interface IRepository<Table_Entity> where Table_Entity:class
    {
        IEnumerable<Table_Entity> GetProduct();
        IEnumerable<Table_Entity> GetAllRecords();
        IQueryable<Table_Entity> GetAllRecordsIQueryable();
        int GetAllrecordCount();
        void Add(Table_Entity entity);
        void Update(Table_Entity entity);
        void UpdateByWhereClause(Expression<Func<Table_Entity, bool>> wherePredict, Action<Table_Entity> ForEachPredict);
        Table_Entity GetFirstorDefault(int recordId);
        void Remove(Table_Entity entity);
        void RemovebyWhereClause(Expression<Func<Table_Entity, bool>> wherePredict);
        void RemoveRangeBywhereClause(Expression<Func<Table_Entity, bool>> wherePredict);
        void InactiveAndDeleteMarkByWhereClause(Expression<Func<Table_Entity, bool>> wherePredict, Action<Table_Entity> ForEachPredict);
        Table_Entity GetFirstorDefaultByParameter(Expression<Func<Table_Entity,bool>> wherePredict);
        IEnumerable<Table_Entity> GetListParameter(Expression<Func<Table_Entity,bool>> wherePredict);
        IEnumerable<Table_Entity> GetResultBySqlProcedure(string query, params object[] parameters);

        IEnumerable<Table_Entity> GetRecordsToShow(int PageNumber, int PageSize, int CurrentPage, Expression<Func<Table_Entity, bool>> wherePredict, Expression<Func<Table_Entity, int>> orderByPredict);
    }

}