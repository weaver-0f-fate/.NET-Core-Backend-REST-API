using Core.Models;
using Services.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Intrefaces {
    public interface IService<TModel, TDTO> where TModel : AbstractModel where TDTO : AbstractDTO {
        Task<IEnumerable<TDTO>> GetAllItemsAsync();
        Task<TDTO> GetByIdAsync(int id);
        Task CreateAsync(TDTO item);
        Task UpdateAsync(TDTO item);
        Task DeleteAsync(TDTO item);

    }
}
