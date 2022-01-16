using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Intrefaces {
    public interface ICrudService<T> where T : AbstractModel {
        Task<IEnumerable<T>> GetAllItemsAsync();
        Task<T> GetAsync(int? id);
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task DeleteAsync(int id);

    }
}
