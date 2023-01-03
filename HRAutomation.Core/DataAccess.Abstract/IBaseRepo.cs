using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRAutomation.Core.DataAccess.Abstract
{
    public interface IBaseRepo<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> AddRange(List<T> entities);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<int> Save();
        Task<T> GetDefault(Expression<Func<T, bool>> expression);
        Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression);
        Task<TResult> GetFilteredFirstOrDefault<TResult>
            (Expression<Func<T, TResult>> select, 
            Expression<Func<T, bool>> where, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<List<TResult>> GetFilteredList<TResult>
            (Expression<Func<T, TResult>> select, 
            Expression<Func<T, bool>> where, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
