using Core.Models;
using Services.DataTransferObjects.OperationTypesDTOs;
using Services.Intrefaces;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOperationTypesService : IService<OperationType, OperationTypeDTO> {

        public Task CreateOperationTypeAsync(OperationTypeForCreateDTO operationTypeDTO);
        public Task UpdateOperationTypeAsync(int id, OperationTypeForUpdateDTO operationTypeDTO);
    }
}
