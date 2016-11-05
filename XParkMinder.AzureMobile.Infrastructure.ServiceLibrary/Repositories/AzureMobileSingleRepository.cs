using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.Sync;
using XParkMinder.Domain.Library.Contracts;
using XParkMinder.Domain.Library.Entities;

namespace XParkMinder.AzureMobile.Infrastructure.ServiceLibrary.Repositories
{
    public class AzureMobileSingleRepository<T> : ISingleRepository<T> where T : BaseEntity
    {

        private ParkMinderDbContext _context { get; }
        private IMobileServiceSyncTable<T> _azureTable { get; }

        public AzureMobileSingleRepository(ParkMinderDbContext context)
        {
            _context = context;
            _azureTable = _context.GetTable<T>();
        }

        public async Task<T> GetOneAsync(Guid id)
        {
            return await GetOneAsync(x => x.Id == id);
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _azureTable.Where(predicate).Take(1).ToEnumerableAsync();
            return result.Single();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _azureTable.Where(predicate).ToEnumerableAsync();
            return result;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _azureTable.InsertAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await _azureTable.UpdateAsync(entity);
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            await _azureTable.DeleteAsync(entity);
            return entity;
        }
    }
}
