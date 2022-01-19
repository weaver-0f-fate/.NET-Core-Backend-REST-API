using Core.Models;
using Services.DataTransferObjects.OperationTypesDTOs;
using Services.Intrefaces;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOperationTypesService : IService<OperationType, OperationTypeDTO> {

        public Task<OperationTypeDTO> CreateOperationTypeAsync(OperationTypeForCreateDTO operationTypeDTO);
        public Task<OperationTypeDTO> UpdateOperationTypeAsync(int id, OperationTypeForUpdateDTO operationTypeDTO);
    }
}
