using Core.Models;
using Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Intrefaces {
    public interface IService<TModel, TDTO> where TModel : AbstractModel where TDTO : AbstractDTO {
        public Task<IEnumerable<TDTO>> GetAllItemsAsync();
        public Task<TDTO> GetByIdAsync(Guid id);
        public Task<TDTO> CreateAsync(TDTO item);
        public Task<TDTO> UpdateAsync(TDTO item);
        public Task DeleteAsync(Guid id);
        public Task<bool> ExistsAsync(Guid id);
    }
}
