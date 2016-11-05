using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XParkMinder.Domain.Library.Entities;

namespace XParkMinder.Domain.Library.Contracts
{
    public interface ISingleRepository<T> where T : BaseEntity
    {
        Task<T> GetOneAsync(Guid id);
        Task<T> GetOneAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}