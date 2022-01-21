using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Interfaces {
    public interface IRepository<T> : IDisposable where T : AbstractModel {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task SaveChangesAsync();
    }
}
