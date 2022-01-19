using Core.Models;
using Services.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Intrefaces {
    public interface IService<TModel, TDTO> where TModel : AbstractModel where TDTO : AbstractDTO {
        public Task<IEnumerable<TDTO>> GetAllItemsAsync();
        public Task<TDTO> GetByIdAsync(int id);
        public Task CreateAsync(TDTO item);
        public Task UpdateAsync(TDTO item);
        public Task DeleteAsync(int id);
        public Task<bool> ExistsAsync(int id);
    }
}
