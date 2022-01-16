using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Intrefaces {
    public interface IService<T> where T : AbstractModel {
        Task<IEnumerable<T>> GetAllItemsAsync();
        Task<T> GetAsync(int? id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);

    }
}
