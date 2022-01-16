using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories {
    public interface IRepository<T> : IDisposable where T : AbstractModel {
        Task<IEnumerable<T>> GetEntitiesListAsync();
        Task<T> GetEntityAsync(int id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task SaveAsync();
        Task<bool> ExistsAsync(int id);
    }
}
