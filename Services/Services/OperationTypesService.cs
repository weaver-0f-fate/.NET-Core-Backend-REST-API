using AutoMapper;
using Data.Interfaces;
using Core.Models;
using Services.DataTransferObjects.OperationTypesDTOs;
using Services.Interfaces;
using System.Threading.Tasks;

namespace Services.Services {
    public class OperationTypesService : AbstractService<OperationType, OperationTypeDTO>, IOperationTypesService{
        public OperationTypesService(IRepositoryWrapper repository, IMapper mapper) 
            : base(repository.OperationTypes, mapper) { }

        public async Task CreateOperationTypeAsync(OperationTypeForCreateDTO operationTypeDTO) {
            await CreateAsync(Mapper.Map<OperationTypeDTO>(operationTypeDTO));
        }

        public async Task UpdateOperationTypeAsync(int id, OperationTypeForUpdateDTO operationTypeForUpdateDTO) {
            var operationTypeDTO = Mapper.Map<OperationTypeDTO>(operationTypeForUpdateDTO);
            operationTypeDTO.Id = id;
            await UpdateAsync(operationTypeDTO);
        }
    }
}
